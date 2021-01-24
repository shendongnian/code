    abstract class Drawable
    {
      public int x { get; set; }
      public int y { get; set; }
      public abstract void draw(Graphics g);
      public abstract bool IsInside(int x, int y);
    }
