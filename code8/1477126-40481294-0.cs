    public class Shape
    {
        public Color color { get; set; }
        public Point origin { get; set; }
    }
    public class MyRectangle : Shape
    {
        public Size size { get; set; }
        public Rectangle ToRectangle()
        {
            return new Rectangle(origin, size);
        }
    }
    public partial class Form1 : Form
    {
        Point mouseDownPoint;
        public Form1()
        {
            InitializeComponent();
        }
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDownPoint = e.Location;
        }
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            MyRectangle rect = new MyRectangle();
            rect.origin = mouseDownPoint;
            rect.size = Size.Subtract((Size)e.Location, (Size)mouseDownPoint);
            pictureBox1.CreateGraphics().DrawRectangle(new Pen(Brushes.Black), rect.ToRectangle());
        }
    }
