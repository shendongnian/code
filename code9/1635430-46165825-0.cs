    public partial class Form1 : Form
    {
        Bitmap newBitmap;
        Image file;
        int blurAmount = 5;
        public Form1()
        {
            InitializeComponent();
            // Occurs when the pictureBox1 control is clicked.
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
        }
    
        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dr = openFileDialog1.ShowDialog();
            if (dr == DialogResult.OK)
            {
                file = Image.FromFile(openFileDialog1.FileName);
                newBitmap = new Bitmap(openFileDialog1.FileName);
    
                pictureBox1.Image = file;
            }
    
        }
    
        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
    
        }
    
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs)e;
            Point coordinates = me.Location;
    
            for (int x = me.Location.X - 25; x < me.Location.X + 25; x++)
            {
                for (int y = me.Location.Y - 25; y < me.Location.Y + 25; y++)
                {
                    try
                    {
                        Color prevX = newBitmap.GetPixel(x - blurAmount, y);
                        Color nextX = newBitmap.GetPixel(x + blurAmount, y);
                        Color prevY = newBitmap.GetPixel(x, y - blurAmount);
                        Color nextY = newBitmap.GetPixel(x, y + blurAmount);
    
                        int avgR = (int)((prevX.R + nextX.R + prevY.R + nextY.R) / 4);
                        int avgG = (int)((prevX.G + nextX.G + prevY.G + nextY.G) / 4);
                        int avgB = (int)((prevX.B + nextX.B + prevY.B + nextY.B) / 4);
    
                        newBitmap.SetPixel(x, y, Color.FromArgb(avgR, avgG, avgB));
                    }
                    catch (Exception) { }
                }
            }
            pictureBox1.Image = newBitmap;
        }
    }
