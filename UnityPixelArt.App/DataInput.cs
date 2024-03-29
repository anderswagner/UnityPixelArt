using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace UnityPixelArt.App
{
    public class DataInput
    {
        private PixelArtdata _pixelArtData;
        private Bitmap _loadedBitmap, _modifiedBitmap;
        private string _fileName;
        private int x;
        private int y;
        private int xTileSize;
        private int yTileSize;
        private int xTiles;
        private int yTiles;

        public DataInput(string path)
        {    
            _fileName = path;
            if (!LoadImage(path)){
                Console.WriteLine("Please input a valid file-path");
                return;
            }
            List<int> values = new List<int>();
            while (values.Count < 6){
                string toWrite = "";
                switch(values.Count){
                    case 0:
                        toWrite = "Input X Tile Size";
                        break;
                    case 1:
                        toWrite = "Input Y Tile Size";
                        break;
                    case 2:
                        toWrite = "Input X Offset";
                        break;
                    case 3:
                        toWrite = "Input Y Offset";
                        break;
                    case 4:
                        toWrite = "Input X Padding";
                        break;
                    case 5:
                        toWrite = "Input Y Padding";
                        break;
                }
                Console.WriteLine(toWrite);
                string x = Console.ReadLine();
                values.Add(int.Parse(x));
            }
            _pixelArtData = new PixelArtdata(values[0], values[1], values[2], values[3], values[4], values[5]);
            Console.WriteLine($"\nYou have added all info. \n{_pixelArtData}\n");

            ModifyBitmap();
        }

        //TODO: Make this async to provide feedback how far in the progress we are
        private void ModifyBitmap()
        {
            x = _loadedBitmap.Width - _pixelArtData.XOffset;
            y = _loadedBitmap.Height - _pixelArtData.YOffset;
            xTileSize = _pixelArtData.XTileSize + (_pixelArtData.XPadding*2);
            yTileSize = _pixelArtData.YTileSize + (_pixelArtData.YPadding*2);
            xTiles = x/xTileSize;
            yTiles = y/yTileSize;
            
            _modifiedBitmap = new Bitmap(_pixelArtData.XOffset + (xTiles*(xTileSize + 2)), _pixelArtData.YOffset + (yTiles*(yTileSize +2)));
            for(int i = 0; i < xTiles; i++){
                for (int j = 0; j < yTiles; j++){
                    TransferTile(i, j);
                    AddEdges(i, j);
                }
            }
            
            _modifiedBitmap.Save(_fileName.Substring(0,_fileName.Length-4) + "_modified.png");
            Console.WriteLine($"Saved file at {_fileName.Substring(0,_fileName.Length-4)}_modified.png");
        }
        private void TransferTile(int xI, int yI)
        {
            int newXPos = _pixelArtData.XOffset + (xI * (xTileSize + 2)) + 1;
            int newYPos = _pixelArtData.YOffset + (yI * (yTileSize + 2)) + 1;
            int oldXPos = _pixelArtData.XOffset + (xI * xTileSize);
            int oldYPos = _pixelArtData.YOffset + (yI * yTileSize);
            for(int i = 0; i < _pixelArtData.XTileSize; i++){
                for(int j = 0; j < _pixelArtData.YTileSize; j++){
                    Color pixelColor = _loadedBitmap.GetPixel(oldXPos+i, oldYPos+j);
                    _modifiedBitmap.SetPixel(i+newXPos,j+newYPos, pixelColor);
                }
            }
        }
        private void AddEdges(int xI, int yI)
        {
            int newXPos = _pixelArtData.XOffset + (xI * (xTileSize + 2)) + 1;
            int newYPos = _pixelArtData.YOffset + (yI * (yTileSize + 2)) + 1;
            for(int i = 0; i < _pixelArtData.XTileSize; i++){
                _modifiedBitmap.SetPixel(i+newXPos,newYPos-1, _modifiedBitmap.GetPixel(i+newXPos, newYPos));
                _modifiedBitmap.SetPixel(i+newXPos,newYPos + yTileSize, _modifiedBitmap.GetPixel(i+newXPos, newYPos + yTileSize - 1));
            }
            for(int i = -1; i < _pixelArtData.YTileSize+1; i++){
                _modifiedBitmap.SetPixel(newXPos-1, i+newYPos, _modifiedBitmap.GetPixel(newXPos, i+newYPos));
                _modifiedBitmap.SetPixel(newXPos+xTileSize, i+newYPos, _modifiedBitmap.GetPixel(newXPos+xTileSize-1, i+newYPos));
            }
        }


        public Bitmap GetLoadedBitmap()
        {
            return _loadedBitmap;
        }

        private bool LoadImage(string path)
        {
            string filePath = $"{Environment.CurrentDirectory}\\{path}";
            try
            {
                _loadedBitmap = (Bitmap) Image.FromFile(filePath);
                return true;
            } catch (FileNotFoundException e){
                Console.WriteLine(e);
                Console.WriteLine(filePath);
            }
            return false;
        }
    }
}