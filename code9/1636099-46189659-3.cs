    namespace PictureBoxDrawing
    {
      public partial class Form1 : Form
      {
        private Bitmap _bmpImage;
    
        public Form1()
        {
          InitializeComponent();
        }
    
        protected override void OnLoad(EventArgs e)
        {
          base.OnLoad(e);
    
          _bmpImage = new Bitmap(@"C:\Image.jpg");
          InitializePictureBox(_bmpImage);
        }
    
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
          DrawPictureBox(pictureBox1, 10, 10, checkBox1.Checked);
        }
    
        private void button1_Click(object sender, EventArgs e)
        {
          DrawPictureBox(pictureBox1, 10, 10, checkBox1.Checked);
        }
    
        private void button2_Click(object sender, EventArgs e)
        {
          InitializePictureBox(_bmpImage);
        }
    
        private void DrawPictureBox(PictureBox pb, int x, int y, bool drawBlue)
        {
          using (Graphics g = pb.CreateGraphics())
          {
            g.FillRectangle(Brushes.Red, x,y, 9,9);
    
            if(drawBlue)
              g.FillRectangle(Brushes.Blue, x, y, 7, 7);
          }
        }
    
        private void InitializePictureBox(Bitmap bmp)
        {
          pictureBox1.Image = bmp;
        }
      }
    }
