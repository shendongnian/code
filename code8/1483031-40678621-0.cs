    internal class Sprite
    {
        public Input Input { get; set; }
        ... 
    }
    internal class Input
    {
        public Key Left { get; private set; }
        public Key Right { get; private set; }
        public Key Up { get; private set; }
        public Key Down { get; private set; }
        public Input(Key left, Key right, Key up, Key down)
        {
            Left = left;
            Right = right;
            Up = up;
            Down = down;
        }
    }
