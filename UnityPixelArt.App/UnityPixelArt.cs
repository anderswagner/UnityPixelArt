using System;
using System.Collections.Generic;
using System.Drawing;

namespace UnityPixelArt.App
{
    public class UnityPixelArtRunner
    {   
        public static void Main(string[] args)
        {
            if (args.Length == 0){
                Console.WriteLine("Please input a file to update");
                return;
            }
            DataInput inputter = new DataInput(args[0]);
            
        }
    }  
}
