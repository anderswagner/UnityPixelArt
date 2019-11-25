using System;
using System.Collections.Generic;

namespace UnityPixelArt.App
{
    class UnityPixelArt
    {
        private static PixelArtdata _pixelArtData;
        static void Main(string[] args)
        {
            List<int> values = new List<int>();
            while (values.Count < 6){
                string x = Console.ReadLine();
                values.Add(int.Parse(x));
            }
            //Seperate constructor
            _pixelArtData = new PixelArtdata(values[0], values[1], values[2], values[3], values[4], values[5]);
            Console.WriteLine($"You have added all info {_pixelArtData}");
        }
    }
}
