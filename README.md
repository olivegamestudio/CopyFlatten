# CopyFlatten
Copy source files recursively but place in a single destination folder in a flattened form:

## Usage

```
copyflatten sourcePath destPath filePattern
```

### Example

```
copyflatten c:\source c:\dest *.png
```

If you have PNGs located in the following structure

```
c:\source
    + image1.png
    + folder
        + image2.png
        + folder2
            + image3.png
```

Then the output would become:

```
c:\dest
    + image1.png
    + image2.png
    + image3.png
```
