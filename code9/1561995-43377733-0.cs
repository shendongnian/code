        public partial class Form1 : Form
        {
            Point p = new Point();
        
            public Form1()
            {
                InitializeComponent();
                this.ResizeEnd += Form1_ResizeEnd;
                SetDimension();
            }
        
            void SetDimension()
            {
                p = new Point(this.Width, this.Height);
            }
        
            void Form1_ResizeEnd(object sender, EventArgs e)
            {
                //check to avoid save if form was just moved...
                if (this.Width != p.X || this.Height != p.Y)
                {
                    SetDimension();
                    MessageBox.Show( string.Format("Width={0} Height={1}, save your settings!", this.Width, this.Height));
                }        
            }
    
    }
