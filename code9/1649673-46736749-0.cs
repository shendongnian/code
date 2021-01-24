    public class Palette
    {
        Direction _direction;
        public Direction Direction
        {
            set { this._direction = value; }
            get { return this._direction; }
        }
    }
    public enum Direction
    {
        Left, Right, Up, Down
    }
    public partial class Form1 : Form
    {
        private Palette p;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            p = new Palette { Direction = Direction.Up };
        }
    }
