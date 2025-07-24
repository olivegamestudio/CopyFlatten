# CopyFlatten

A simple command-line utility that recursively searches a directory tree and copies all matching files to a single flat destination directory.

## Usage

```bash
CopyFlatten.exe <source-directory> <destination-directory> <file-pattern>
```

**Parameters:**
- `source-directory` - The root directory to search recursively
- `destination-directory` - The target directory where all files will be copied (created if it doesn't exist)
- `file-pattern` - The file pattern to match (supports wildcards like `*.dll`, `*.txt`, etc.)

## What It Does

1. **Recursively searches** the source directory for files matching the pattern
2. **Creates the destination directory** if it doesn't exist
3. **Copies all matching files** to the destination directory (flattened structure)
4. **Overwrites existing files** in the destination if they have the same name

## Examples

### Copy All DLL Files
```bash
CopyFlatten.exe "C:\MyProject\bin" "C:\AllDlls" "*.dll"
```
Copies all `.dll` files from any subdirectory of `C:\MyProject\bin` into `C:\AllDlls`.

### Copy All Images
```bash
CopyFlatten.exe "C:\Photos" "C:\AllPhotos" "*.jpg"
```
Flattens a photo directory structure, copying all JPG files to a single folder.

### Copy Configuration Files
```bash
CopyFlatten.exe "C:\Application" "C:\Configs" "*.config"
```
Extracts all configuration files from an application directory tree.

### Copy All Files
```bash
CopyFlatten.exe "C:\Source" "C:\Destination" "*.*"
```
Copies every file from the source directory tree into a flat structure.

## Common Use Cases

### 1. Library Collection
Gather all shared libraries from a complex project structure:
```bash
CopyFlatten.exe "C:\Solution\Projects" "C:\Deploy\Libraries" "*.dll"
```

### 2. Asset Extraction
Extract all assets of a specific type from a game or application:
```bash
CopyFlatten.exe "C:\Game\Assets" "C:\ExtractedTextures" "*.png"
```

### 3. Log File Aggregation
Collect log files from multiple subdirectories:
```bash
CopyFlatten.exe "C:\Logs\2023" "C:\AllLogs" "*.log"
```

### 4. Documentation Collection
Gather documentation files from various project folders:
```bash
CopyFlatten.exe "C:\Projects" "C:\AllDocs" "*.md"
```

### 5. Build Artifact Collection
Collect build outputs from multiple projects:
```bash
CopyFlatten.exe "C:\Solution" "C:\BuildOutputs" "*.exe"
```

## Directory Structure Example

**Before (Source Structure):**
```
C:\MyProject\
├── Core\
│   ├── MyApp.Core.dll
│   └── Utils\
│       └── MyApp.Utils.dll
├── Data\
│   └── MyApp.Data.dll
└── Web\
    ├── MyApp.Web.dll
    └── Plugins\
        └── MyApp.Plugins.dll
```

**After Running:** `CopyFlatten.exe "C:\MyProject" "C:\FlatOutput" "*.dll"`
```
C:\FlatOutput\
├── MyApp.Core.dll
├── MyApp.Utils.dll
├── MyApp.Data.dll
├── MyApp.Web.dll
└── MyApp.Plugins.dll
```

## Integration Examples

### Batch Script
```batch
@echo off
echo Flattening DLL files...
CopyFlatten.exe "%SOURCE_DIR%" "%DEPLOY_DIR%\libs" "*.dll"

echo Flattening config files...
CopyFlatten.exe "%SOURCE_DIR%" "%DEPLOY_DIR%\configs" "*.config"

echo Done!
```

### PowerShell
```powershell
$sourceDir = "C:\Build\Output"
$deployDir = "C:\Deploy"

# Flatten different file types to separate directories
& "CopyFlatten.exe" $sourceDir "$deployDir\Libraries" "*.dll"
& "CopyFlatten.exe" $sourceDir "$deployDir\Executables" "*.exe"
& "CopyFlatten.exe" $sourceDir "$deployDir\Configs" "*.config"

Write-Host "Files flattened successfully!"
```

### CI/CD Pipeline
```bash
# In a build script
echo "Collecting build artifacts..."
./CopyFlatten "/build/output" "/artifacts/binaries" "*.dll"
./CopyFlatten "/build/output" "/artifacts/executables" "*.exe"
```

## File Pattern Examples

| Pattern | Matches |
|---------|---------|
| `*.dll` | All DLL files |
| `*.exe` | All executable files |
| `*.txt` | All text files |
| `*.config` | All configuration files |
| `*.*` | All files with extensions |
| `MyApp.*` | All files starting with "MyApp" |
| `*.log` | All log files |
| `test*.cs` | C# files starting with "test" |

## Important Notes

### File Overwrites
- **Files with the same name will be overwritten** in the destination
- The last file processed (alphabetically) will be the final version
- Consider this when flattening directories with duplicate filenames

### Name Conflicts
If multiple files have the same name but are in different source directories:
```
Source/
├── Folder1/config.xml  ← This will be overwritten
└── Folder2/config.xml  ← This will be the final file
```

Only the last `config.xml` processed will remain in the destination.
