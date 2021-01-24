     public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
    
        }
    
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            // for the image move 
            int x = Convert.ToInt32(HeartSprite.Location.X);
            int y = Convert.ToInt32(HeartSprite.Location.Y);
    
            if (e.KeyCode == Keys.Right) x += 25;
            else if (e.KeyCode == Keys.Left) x -= 25;
            else if (e.KeyCode == Keys.Up) y -= 25;
            else if (e.KeyCode == Keys.Down) y += 25;
    
            HeartSprite.Location = new Point(x, y);
    
            e.Handled = true;
        }
    }
