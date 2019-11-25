using System;
using Xunit;
using UnityPixelArt.App;

namespace UnityPixelArt.Tests
{
    public class DataInputTests
    {
        [Fact]
        public void Test_Loading_File()
        {
            DataInput dataInput = new DataInput("TestData/Monkey.png");
            
        }

        [Fact]
        public void Modifying_Unnecessary_File()
        {
            
        }
    }
}
