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
        public DataInput(string path)
        {    
            if (!LoadImage(path)){
                Console.WriteLine("Please input a valid file-path");
                return;
            }
            Console.WriteLine(_loadedBitmap.Height);
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

        private void ModifyBitmap()
        {
            Console.WriteLine(_loadedBitmap.GetPixel(_loadedBitmap.Height/2, 8));
        }

        public Image GetLoadedBitmap(){
            return _loadedBitmap;
        }
        private bool LoadImage(string path)
        {
            string filePath = path;
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