    public class RectangleInfo
    {
        public RectangleInfo(Rectangle rect, bool leftOverlap, bool rightOverlap)
		{
            Rectangle = rect;
            LeftOverlap = leftOverlap;
            RightOverlap = rightOverlap;
		}
        public Rectangle Rectangle { get; set; }
		public bool LeftOverlap { get; set; }
		public bool RightOverlap { get; set; }
	}
