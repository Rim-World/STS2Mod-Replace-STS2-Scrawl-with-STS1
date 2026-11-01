# 潦草急就替换（Scrawl Replacement）

将《杀戮尖塔 2》无色金卡「潦草急就」（Scrawl）整卡替换为《杀戮尖塔 1》同名卡牌的样式：
升级后 1 费变 0 费（不再获得保留），卡名、卡面描述、卡图一并改用 STS1 版本。

Replaces the Slay the Spire 2 colorless Rare card **Scrawl** with its Slay the Spire 1
counterpart: the upgraded card costs 0 instead of gaining Retain, and the title,
description and portrait are taken from STS1.

## 功能

| 项目 | 改动 |
|---|---|
| 升级效果 | 原版为 `AddKeyword(Retain)`（仍 1 费）；本 mod 改为 `EnergyCost.UpgradeBy(-1)`，升级后 0 费 |
| 卡名与描述 | 使用 `RE_SCRAWL.title` / `RE_SCRAWL.description` 键，覆盖 15 种语言，文本取自 STS1 |
| 卡图 | 使用 STS1 原版卡图（1000×760 大图 + 250×190 手持图），pck 加载失败时回退到 DLL 内嵌 PNG |
| 实现方式 | 直接在原卡牌上打 Harmony 补丁，不生成新卡牌、不禁用旧卡牌 |

基础版效果（1 费、抽牌至手牌补满、消耗）与 STS2 原版一致，`OnPlay` 未打补丁。

## 兼容性

- 支持游戏 `default v0.107.1` 与 `public beta v0.111.0`，单份 DLL 同时适配两版。
- manifest 声明 `min_game_version = 0.107.1`。
- 不依赖任何前置 mod。文本键使用 `RE_SCRAWL.*` 前缀，避免与其它 mod 冲突。
- 已知缺口：v0.111 新增的第 16 种语言 `ind`（印尼语）未提供文本，该语言下会缺键。

## 安装

1. 将 `ScrawlReplacementMod` 目录整体放入游戏的 `mods/` 目录。
2. 启动游戏，在 mod 列表中启用本 mod。
3. 目录内应包含 `ScrawlReplacementMod.dll`、`ScrawlReplacementMod.pck`、`ScrawlReplacementMod.json`
   （`.pdb` 为调试符号，可选）。

从源码构建见下一节；发布包见仓库 Release 页。

## 构建

前置：.NET 9 SDK、Godot 4.5.1 mono 版、本机已安装《杀戮尖塔 2》。

```powershell
pwsh -File 9.SRC/ScrawlReplacementMod/build.ps1
```

`build.ps1` 依次执行：`dotnet build`（Debug / MSIL）→ Godot `--headless --import`
→ Godot `--export-pack "Windows Desktop"` → 把 dll、pdb、json 连同 pck 复制到
`<游戏目录>/mods/ScrawlReplacementMod`。

工程引用本机 `data_sts2_windows_x86_64/sts2.dll` 与 `0Harmony.dll`（`Private=false`，不随发布），
因此 `ScrawlReplacementMod.csproj` 中的 `Sts2Path`、`GodotPath` 需按本机路径调整。

## 目录结构

| 目录 | 内容 |
|---|---|
| `1.ADR/` | 架构决策记录 |
| `2.PLANS/` | 施工计划 |
| `3.DOCS/` | 知识与报告 |
| `4.SDD/` | 软件设计文档 |
| `5.ChangeLog/` | 版本日志分片 |
| `9.SRC/` | 源码（`ScrawlReplacementMod/` 为 Godot + C# 工程根） |
| `10.OUTPUT/` | 构建产物与发布包（本地目录，不入库） |
| `PRIVACY/` | 机密信息占位（不入库） |
| `TMP/` | 临时与过程文件（不入库） |
| `TOOLS/` | 工具与自写脚本 |
| `description/` | 创意工坊文案（中/英） |
| `pics/` | 封面与截图素材 |

## 文档索引

- [ADR 索引](1.ADR/ADR.md) —— 决策：整卡替换方案、补丁面、兼容策略
- [计划索引](2.PLANS/PLANS.md) —— 施工计划与施工记录回填
- [文档索引](3.DOCS/DOCS.md) —— STS1/STS2 取证、本地化与卡图处理要点
- [SDD 索引](4.SDD/SDD.md) —— 总体设计
- [版本日志索引](5.ChangeLog/ChangeLog.md) —— 按版本分片
- [CHANGELOG.md](CHANGELOG.md) —— Keep a Changelog 单文件日志

## 版本

当前版本 **1.0**（2026-08-15 构建）。

## 致谢

本 mod 使用 Opencode（桌面版）+ DeepSeek V4 Flash（0731 正式版）完成。

感谢《杀戮尖塔 2》制作组为 mod 制作提供的便利；感谢 Baselib 制作者提供的文档；
感谢 GitHub 项目 [@jiegec/STS2RevertAnthony](https://github.com/jiegec/STS2RevertAnthony)
提供的源码参考。

## 开源地址

<https://github.com/Rim-World/STS2Mod-Replace-STS2-Scrawl-with-STS1>

许可协议见 [LICENSE](LICENSE)（MIT）。创意工坊文案见 [description/潦草_中文.md](description/潦草_中文.md)
与 [description/潦草_英文.md](description/潦草_英文.md)。
