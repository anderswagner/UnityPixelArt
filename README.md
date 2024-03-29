# UnityPixelArt

UnityPixelArt is a command-line tool to fix gaps between objects by adding redudant edges to all tiles of a spritesheet.

## How to use

Insert the following line into your PATH system variable (Google how to do it if you're unsure)

``LOCATION_OF_FOLDER\UnityPixelArt.App\bin\Release\netcoreapp3.0\publish``

From the command-line you can now type ``PixelFix {FileName}`` (Include extension, ".png").

The command line will now start asking for data, all units are in pixels  
"Input X Tile Size" - The Horizontal size of every tile.  
"Input Y Tile Size" - The Vertical size of every tile.  
"Input X Offset" - The X Offset from the top left corner.  
"Input Y Offset" - The Y Offset from the top left corner.  
"Input X Padding" - The X Padding between each tile.  
"Input Y Padding" - The Y Padding between each tile.  

This will output a file (filename suffixed with _modified.png) with redundant edges to fix the pixel-gaps.

## TODO

Progress bar by using async method calls while modifying each tile.
