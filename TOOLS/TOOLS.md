# 工具与脚本索引

| 时间 | 工具/脚本 | 用途 | 版本 | 大小 | 来源 | 安装方式/依赖 |
|---|---|---|---|---|---|---|
| — | （无） | — | — | — | — | — |

## 说明

- 本仓库未在 `TOOLS/` 下收纳独立工具或自写脚本，`TOOLS/scripts/` 当前为空。
- 构建所需的工具为系统级安装，不放入项目目录：
  - .NET SDK 9（`dotnet build`）
  - Godot 4.5.1 mono 版（`--headless --import` / `--export-pack`），路径在 `build.ps1` 与
    `ScrawlReplacementMod.csproj` 中写死为 `C:/Godot&GDRE/Godot_v4.5.1-stable_mono_win64/`。
- 工程自带的构建脚本 `build.ps1` 属于源码的一部分，位于 `9.SRC/ScrawlReplacementMod/`，
  与本目录的通用工具脚本不是一类，故不重复登记。
