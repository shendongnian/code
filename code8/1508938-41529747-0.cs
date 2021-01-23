    public interface RectangleState
        {
            int myHeight { get; set; }
            int myWidth { get; set; }
        }
        public class RectangleModel
        {
            private static Rectangle Rect1;
            public RectangleModel(Rectangle rect1 )
            {
                Rect1 = rect1;
            }        
            private RectangleState state;
            public RectangleState State
            {
                get
                {
                    return state;
                }
                set
                {
                    state = value;
                    ModifyState(value.myHeight, value.myWidth);
                }
            }
            private void ModifyState(int Height, int Width)
            {
                Rect1.Height = Height;
                Rect1.Width = Width;
            }
        }
        public class SmallState : RectangleState
        {
            public int myHeight { get; set; } = 20;
            public int myWidth { get; set; } = 80;
        }
        public class MediumState : RectangleState
        {
            public int myHeight { get; set; } = 25;
            public int myWidth { get; set; } = 90;
        }
        public class LargeState : RectangleState
        {
            public int myHeight { get; set; } = 35;
            public int myWidth { get; set; } = 120;
        }
        public class NormalState : RectangleState
        {
            public int myHeight { get; set; } = 30;
            public int myWidth { get; set; } = 100;
        }
