namespace UnityPixelArt.App
{
    public class PixelArtdata
    {
        private readonly int xTileSize;
        private readonly int yPadding;
        private readonly int xPadding;
        private readonly int yOffset;
        private readonly int xOffset;
        private readonly int yTileSize;

        public int YTileSize => yTileSize;

        public int XOffset => xOffset;

        public int YOffset => yOffset;

        public int XPadding => xPadding;

        public int YPadding => yPadding;

        public int XTileSize => xTileSize;
        public PixelArtdata(int xTileSize, int yTileSize, int xOffset, int yOffset, int xPadding, int yPadding)
        {
            this.xOffset = xOffset;
            this.yOffset = yOffset;
            this.xPadding = xPadding;
            this.yPadding = yPadding;
            this.xTileSize = xTileSize;
            this.yTileSize = yTileSize;
        }
        public PixelArtdata(){

        }

        public override string ToString(){
            return "Hello guys";
        }
    }
}