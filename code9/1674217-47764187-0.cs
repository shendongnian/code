    namespace WindowsFormsApp1
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
    
                // Instantiate an instance of your class.
                Class1 classen = new Class1(new Random().Next(3, 12), new Random().Next(3, 11), new Random().Next(0, 600), 0);
                // Add it to your list.
                listan.Add(classen);
            }
    
            List<Class1> listan = new List<Class1>();
            protected override void OnPaint(PaintEventArgs e)
            {
                Graphics g = e.Graphics;
                Font font = new Font("Arial", 16);
                SolidBrush brush = new SolidBrush(Color.DeepSkyBlue);
    
                //MessageBox.Show("32"); <-- don't do this, it will just popup every time your screen is invalidated.
    
                // Loop through your list.
                for (int i = listan.Count - 1; i >= 0; i--)
                {
                    // Determine if your text has scrolled off the top of the screen.
                    if (listan[i].Y < -e.Graphics.MeasureString(listan[i].A.ToString(), font).Height)
                    {
                        // remove it from the list because it can't be seen anymore, and create a new one.
                        listan.RemoveAt(i);
    
                        Class1 classen = new Class1(new Random().Next(3, 12), new Random().Next(3, 11), new Random().Next(0, 600), new Random().Next(0, 600));
                        // Add it to your list.
                        listan.Add(classen);
    
                    }
                    else
                    {
                        // Draw the item, just like you were before.
                        g.DrawString(listan[i].A.ToString() + "X" + listan[i].B.ToString(), font, brush, listan[i].X, listan[i].Y);
                    }
                }
            }
    
            private void timer1_Tick(object sender, EventArgs e)
            {
                for (int i = 0; i < listan.Count; i++)
                {
                    listan[i].Y -= 1;
                    Invalidate();
                }
            }
        }
    }
    
    class Class1
    {
        private int a;
        private int b;
        private int x;
        private int y;
    
        public Class1(int a, int b, int x, int y)
        {
            this.a = a;
            this.b = b;
            this.x = x;
            this.y = y;
        }
        public int A
        {
            get { return a; }
            set { a = value; }
        }
        public int B
        {
            get { return b; }
            set { b = value; }
        }
        public int X
        {
            get { return x; }
            set { x = value; }
        }
        public int Y
        {
            get { return y; }
            set { y = value; }
        }
    }
