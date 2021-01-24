    public class Tile : GameObject
    {
        public Color Color { get; private set; }
        public Tile(Color color) :base()
        {
            Color = color;
        }
    }
