# 更新日志

本文件遵循 [Keep a Changelog](https://keepachangelog.com/zh-CN/1.1.0/) 格式，版本号遵循
[语义化版本](https://semver.org/lang/zh-CN/)。

## [未发布]

### 变更

- 仓库整理为 AGENTS 十目录结构：`adr/` → `1.ADR/`、`plans/` → `2.PLANS/`、`docs/` → `3.DOCS/`、
  `src/` → `9.SRC/`；补全 `4.SDD/`、`5.ChangeLog/`、`10.OUTPUT/`、`PRIVACY/`、`TMP/`、`TOOLS/`
  与根目录 `README.md`、`CHANGELOG.md`、`.gitignore`。
- 从远端恢复本地缺失的 `README.md`、`README.zh.md`（移入 `9.SRC/ScrawlReplacementMod/`）、
  `LICENSE`（保留在仓库根）。
- 未改动任何源码字节（`.cs` / `.csproj` / `.json` / `.godot` / `.cfg` / `.ps1` 仅随目录移动）。
- 仓库整理提交编号：`436adde9`。

## [1.0] - 2026-08-15

### 新增

- 「潦草急就」（Scrawl）整卡替换：升级后 0 费（原版升级获得保留），对齐《杀戮尖塔 1》。
- 15 种语言的卡名与描述文本（zhs / zht / eng / jpn / kor / spa / esp / ptb / fra / deu /
  rus / ita / pol / tha / tur）。
- STS1 原版卡图：1000×760 大图与 250×190 手持图，附 DLL 内嵌 PNG 兜底。
- 一键构建脚本 `build.ps1`（.NET 构建 → Godot 导入 → 导出 pck → 安装到游戏 `mods/`）。

### 变更

- 补丁只作用于原卡牌实例，不新增卡牌、不禁用旧卡牌；关闭 mod 后恢复原状。
- manifest 声明 `min_game_version = 0.107.1`，单份 DLL 同时兼容游戏 `default 107` 与 `public beta 111`。

### 修复

- 无（首个版本）。

### 已知问题

- 游戏 v0.111 新增的 `ind`（印尼语）未提供文本，该语言下读取 `RE_SCRAWL.*` 会缺键。
- 游戏内验证（图鉴升级预览、实战打出、图鉴滚动、与其它 mod 同开）尚未执行。
