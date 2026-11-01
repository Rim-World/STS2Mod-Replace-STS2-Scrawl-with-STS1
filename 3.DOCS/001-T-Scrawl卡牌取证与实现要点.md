# 研究笔记：ScrawlReplacementMod

> 工程：`9.SRC/ScrawlReplacementMod`，2026-08-15 创建，v1.0 已构建安装

## 卡牌对应关系（关键澄清）

- 用户所称「潦草急就」= 英文 **Scrawl**（不是 Scribble）。已在两作取证：
  - STS1 `desktop-1.0.jar`：`localization/<lang>/cards.json` 键 `Scrawl`（zhs 名"潦草急就"），
    类 `com/megacrit/cardcrawl/cards/purple/Scrawl.class`（观者卡），卡图 `images/1024Portraits/purple/skill/scrawl.png`
  - STS2 全库无 Scribble 键/类；`SCRAWL.title`（zhs=潦草急就）为无色金卡
- STS2 的 `ColorlessCardPool.GenerateAllCards` 含 `ModelDb.Card<Scrawl>()`（无色卡池 65 张之一）

## 两版差异（107 与 111 的 Scrawl.cs 逐字一致）

| 项 | STS2（107/111 同） | STS1 |
|---|---|---|
| 费用 | 1 费 | 1 费（升级 0 费） |
| 类型/稀有 | Skill / Rare / Self | Skill / Rare / 单体 |
| 关键词 | Exhaust | Exhaust |
| OnPlay | 抽牌直到手牌补满（`CardPile.MaxCardsInHand - Hand.Count` 后 `CardPileCmd.Draw`） | 相同 |
| **OnUpgrade** | **`AddKeyword(CardKeyword.Retain)`** | **`upgradeBaseCost`：费用 1→0，效果不变** |

唯一差异 = 升级效果。本 mod 补丁 `Scrawl.OnUpgrade`（Prefix 返回 false 整体替换）为
`__instance.EnergyCost.UpgradeBy(-1)`——官方减费样板（`ShadowStep.OnUpgrade` 同款写法，
`CardEnergyCost.UpgradeBy(int)` 为 public，107/111 逐字一致，行号同为 351）。
`OnPlay` 无需补丁。

## 引擎 API 取证（v0.111.0 / v0.107.1 反编译）

- `CardModel.EnergyCost`（CardModel.cs:379，public getter，懒加载 `_energyCost`）
- `CardEnergyCost.UpgradeBy(int)`（`MegaCrit.Sts2.Core.Entities.Cards`，public，`AssertMutable` 在升级流程内安全）
- 升级预览/图鉴路径：`MutableClone() + UpgradeInternal()` → `OnUpgrade()`，补丁自然生效（计算下注先例验证）
- `LocString` 构造：`new LocString("cards", "RE_SCRAWL.title")`（`MegaCrit.Sts2.Core.Localization`）

## 本地化

- 15 个语言目录（zhs/zht/eng/jpn/kor/spa/esp/ptb/fra/deu/rus/ita/pol/tha/tur），esp 复用 spa。
- 键：`RE_SCRAWL.title` / `.description`（RE_ 前缀防与 CustomCardBalance 等 mod 冲突）。
- 描述 = STS1 原文去 Exhaust 句（Exhaust 徽记由关键词渲染，避免文本+徽记重复），`NL`→`\n`。
- 用户拍板：严格 STS1 原文；仅 zht 补句号（`抽牌直到將手牌抽滿。`）。
- ⚠️ 111 有第 16 语言 `ind`：本 mod 未补 ind 目录，ind 玩家会因 `RE_*` 键缺失抛 LocException。
  用户暂未批准补 ind；如需补齐：卡名 `Tulis Acak`，描述 `Ambil kartu sampai tanganmu penuh.`
  （STS1 原文 `Ambil kartu sampai tanganmu penuh. NL Hangus.` 去 Hangus 句）。

## 卡图

- STS1 源：`images/1024Portraits/purple/skill/scrawl.png`（500×380，P 模式）。
  处理：`convert("RGBA")` → LANCZOS → 1000×760（big）+ 250×190（card_portraits）。
- 模组路径：`res://ScrawlReplacementMod/images/card_portraits/...`。
- 兜底：DLL 内嵌 `assets/scrawl_big.png`（1000×760），`PortraitTextureLoader` pck 优先。

## 构建

- `build.ps1`：dotnet build (Debug, MSIL) → Godot `--headless --import` → `--export-pack Windows Desktop`
  → 拷贝 dll/pdb/json 到 `mods\ScrawlReplacementMod`。
- csproj 引用本机 `data_sts2_windows_x86_64\sts2.dll` + `0Harmony.dll`（Private=false），NoWarn MSB3270。
- manifest：`min_game_version=0.107.1`（107/111 通吃），has_pck/has_dll=true，affects_gameplay=true，
  version=1.0，无 author（用户要求）。
- 构建结果：0 错误 1 警告（CS8603 可空，与先例一致保留）；安装目录 4 个文件（dll 748KB / json / pck 566KB / pdb）。
- 模组图标：**用户已替换**为 `pics/潦草封面_small.png`（420×420 RGB）。
- manifest author：**再玩小卡组找人弄你**（用户决定，本 mod 及全部 6 个兄弟 mod 统一；manifest 其它字段未动）。
- ind 印尼语：**用户决定不补**（按 15 语言发布，ind 玩家 LocException 风险接受）。

## 待办

- [x] 发布用说明文本：`description/潦草_中文.md`（用户已修订）+ `潦草_英文.md`（翻译版）
- [x] 7 个 mod manifest 作者统一为「再玩小卡组找人弄你」并全部重新构建安装（0 错误）
- [ ] 游戏内验证：图鉴升级预览（0 费、无 Retain）、战斗升级版 0 费打出、图鉴滚动无闪动
- [ ] 与既有 mod 同开回归
- [ ] macOS 侧构建验证由用户自行处理（MSIL + pck 跨平台）