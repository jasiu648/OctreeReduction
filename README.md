# Octree Reduction

Octree Reduction is a Windows desktop application that reduces the number of colors in an image with an octree color quantizer. It shows the original and quantized images side by side.

## Features

- Import common image formats from your computer.
- Choose the target color count.
- Preview the original and reduced images side by side.
- Save the generated image.
- Includes several sample images.

## Requirements

- Windows 10 or later.
- [.NET 6 SDK](https://dotnet.microsoft.com/download/dotnet/6.0).
- Visual Studio 2022 (recommended) with the **.NET desktop development** workload.

## Build and run

Open `OctreeReduction.sln` in Visual Studio and press **F5**.

To build and run from PowerShell:

```powershell
dotnet run --project src/OctreeReduction/OctreeReduction.csproj
```

To create a Release build:

```powershell
dotnet build OctreeReduction.sln --configuration Release
```

## Usage

1. Use **Import file** to select an image.
2. Enter the desired number of output colors.
3. Select **Reduce** to generate the quantized image.
4. Use **Save file** to export the result.

The sample images are available in `assets/images/`.

## Project structure

```text
OctreeReduction/
|-- assets/
|   `-- images/                  # Sample source images
|-- src/
|   `-- OctreeReduction/
|       |-- Quantizers/          # Octree quantizer implementation
|       |-- Utils/               # Shared color types
|       |-- Form1.cs             # Main application behavior
|       `-- Form1.Designer.cs    # Windows Forms UI layout
`-- OctreeReduction.sln
```

## How it works

The quantizer inserts RGB values into an 8-level octree. The lowest unused levels are merged until the tree contains approximately the requested number of palette entries. Every source pixel is then mapped to the nearest available palette entry represented by the octree.