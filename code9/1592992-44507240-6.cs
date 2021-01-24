    public abstract class MyDrawingThing {
        public abstract void Draw(Graphics g);
    }
    public class MyPointList : MyDrawingThing {
        public List<Point> Points { get; set; }
        public float PenWidth { get; set; }
        public Color Color { get; set; }
        public override void Draw(Graphics g) {
            using (var p = new Pen(Color, PenWidth)) {
                g.DrawLine(p, Points[0], Points[1]);
            }
        }
    }
