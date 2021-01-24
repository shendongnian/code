    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
    
    
        private void Form1_Load(object sender, EventArgs e)
        {
            Example();
        }
    
        // space beetween controls (top and right)
        public int MarginSpace = 8;
        // first element location
        public Point StartPoint = new Point(10, 10);
        private void Example()
        {
            var fixesWidth = 70;
            List<Label> randomLables = new List<Label>();
            Random rand = new Random();
            // generate lables with random heights
            for (int i = 1; i < 10; i++)
            {
                Label lr = new Label();
                var randheight = rand.Next(60, 120);
                lr.Size = new Size(fixesWidth, randheight);
                lr.Text = i.ToString();
                lr.BackColor = Color.Black;
                lr.ForeColor = Color.White;
                randomLables.Add(lr);
            }
    
            // check how many elements in one "column" (possible also to add right+left margin)
            var cols = panel1.Width / fixesWidth;
            // create matrix object to get locations of each label
            MyMatrix m = new MyMatrix(cols, randomLables.Count, 15, 70, StartPoint);
            m.SetMatrix(randomLables);
            int counter = 0;
            // pupulate all lables with the points from MyMatrix object
            foreach (Point p in m.pointsMatrix)
            {
                randomLables[counter].Location = p;
                panel1.Controls.Add(randomLables[counter]);
                counter++;
            }
        }
    }
    class MyMatrix
    {
        private int Rows;
        private int TotalElements;
        private int Cols;
        private int Margin;
        private int ElementWidth;
        private Point StartPoint;
        public MyMatrix(int cols, int totalelements, int margin, int elementwidth, Point startingpoint)
        {
            this.Cols = cols;
            this.TotalElements = totalelements;
            this.Margin = margin;
            this.ElementWidth = elementwidth;
            this.StartPoint = startingpoint;
    
            // calculate number of rows
            Rows = totalelements / cols;
        }
    
        public List<Point> pointsMatrix = new List<Point>();
        int cellCounter = 0;
        public void SetMatrix(List<Label> Labels)
        {
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Cols; j++)
                {
    
                    var x = StartPoint.X + j * (Margin + ElementWidth);
                    var y = StartPoint.Y;
                    if (cellCounter >= Cols)
                    {
                        // find the parallel cell in the row above
                        y = pointsMatrix[cellCounter - Cols].Y + Labels[cellCounter - Cols].Height + Margin;
                    }
                    else
                    {
                        // do nothing it is first row
                    }
    
                    Point p = new Point(x, y);
                    pointsMatrix.Add(p);
                    cellCounter += 1;
                }
            }
        }
    }
