# 构建产物与发布包索引

> `10.OUTPUT/` 除本索引外全部被 `.gitignore` 排除，不随仓库分发。

| 时间 | 名称 | 版本号 | 大小 | 说明 |
|---|---|---|---|---|
| 2026-11-01 | `02-发布包/ScrawlReplacementMod.v1.0.zip` | 1.0 | 1 587 778 B（约 1.6 MB） | Release `v1.0` 运行包：`ScrawlReplacementMod/` 下 dll、pck、json、pdb 四个文件；已排除游戏目录中的 `.sts2-workshop-uploader/` |
| 2026-11-01 | `02-发布包/ScrawlReplacementModSourceCode.zip` | 1.0 | 1 716 069 B（约 1.7 MB） | Release `v1.0` 源码包：`9.SRC/ScrawlReplacementMod/` 全部 42 个文件（不含 `.godot/`、`bin/`、`obj/`、`*.dll`、`*.pck`、`*.pdb`） |

## 目录说明

| 子目录 | 用途 | 当前状态 |
|---|---|---|
| `01-构建产物/` | 本地构建产物归档 | 空：构建结果由 `build.ps1` 直接写入游戏目录 `mods/ScrawlReplacementMod/`，需要归档时从此处复制 dll/pck/json/pdb |
| `02-发布包/` | GitHub Release 资产 | 2 个 zip，见上表 |
| `03-备份/` | 旧版本产物与备份 | 空 |

## 已安装构建（游戏目录，不在本仓库）

`C:/Game/Steam/steamapps/common/Slay the Spire 2/mods/ScrawlReplacementMod/`

| 文件 | 大小 | 说明 |
|---|---|---|
| `ScrawlReplacementMod.dll` | 748 544 B | .NET 9 / MSIL 程序集 |
| `ScrawlReplacementMod.pck` | 838 868 B | Godot 资源包（卡图、15 语言、模组图标） |
| `ScrawlReplacementMod.json` | 538 B | mod 清单，`version 1.0`、`min_game_version 0.107.1` |
| `ScrawlReplacementMod.pdb` | 13 896 B | 调试符号（可选） |

> `.sts2-workshop-uploader/` 为创意工坊上传工具的本地状态目录，仅为打包时排除的对象，未包含在上表与任何发布资产中。
