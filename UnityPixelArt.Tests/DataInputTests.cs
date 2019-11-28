using System;
using Xunit;
using UnityPixelArt.App;
using System.Drawing;
using System.IO;
using System.Reflection;

namespace UnityPixelArt.Tests
{
    public class DataInputTests
    {
        [Fact]
        public void Test_Correct_PixelArtData()
        {
            PixelArtData expectedData = new PixelArtData(16,16,16,16,16,16);
            
        }
    }
}
