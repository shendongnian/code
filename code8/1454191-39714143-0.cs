    public class XYButton : Button
    {
        private int xPos;
        private int yPos;
    
        public XYButton(int x, int y)
        {
            xPos = x;
            yPos = y;
        }
    
        public int GetX()
        {
            return xPos;
        }
    
        public int GetY()
        {
            return yPos;
        }
    }
