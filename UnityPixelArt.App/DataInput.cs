using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection;

namespace UnityPixelArt.App
{
    public class DataInput
    {
        private PixelArtdata _pixelArtData;
        private Bitmap _loadedBitmap, _modifiedBitmap;
        private string _fileName;
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
            int x = _loadedBitmap.Width - _pixelArtData.XOffset;
            int y = _loadedBitmap.Height - _pixelArtData.YOffset;
            int xTileSize = _pixelArtData.XTileSize + (_pixelArtData.XPadding*2);
            int yTileSize = _pixelArtData.YTileSize + (_pixelArtData.YPadding*2);
            int xTiles = x/xTileSize;
            int yTiles = y/yTileSize;
            _modifiedBitmap = new Bitmap(_pixelArtData.XOffset + (xTiles*(xTileSize + 2)), _pixelArtData.YOffset + (yTiles*(yTileSize +2)));
            _modifiedBitmap.Save(_fileName.Substring(0,_fileName.Length-4) + "_modified.png");
        }

        public Bitmap GetLoadedBitmap(){
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