    public partial class Form1 : Form
        {
            private List<Point> _points = null;
    
            public Form1()
            {
                InitializeComponent();
    
                _points = new List<Point>();
    
                this.MouseMove += Form1_MouseMove;
            }
    
            private void Form1_MouseMove(object sender, MouseEventArgs e)
            {
                //Save the point
                _points.Add(new Point(e.X, e.Y));
            }
    
            private void PerformRecord()
            {
                foreach (var point in _points)
                {
                    this.Cursor = new Cursor(Cursor.Current.Handle);
                    Cursor.Position = new Point(point.X, point.Y);
                }
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                PerformRecord();
            }
        }
