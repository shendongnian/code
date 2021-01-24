     public partial class Form1 : Form
        {
            private bool isFirstOne;
            Image forSwap;
            public Form1()
            {
                InitializeComponent();
            string path1 = @"C:\Users\...\...\somePic.png";
          
            pictureBox1.Image = Image.FromFile(path1);
          
            forSwap = null;
            isFirstOne = false;
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            switch (isFirstOne)
            {
                case true:
                    forSwap = pictureBox2.Image;
                    pictureBox1.Image = pictureBox2.Image;
                    pictureBox2.Image = null;
                    break;
                case false:
                    forSwap = pictureBox1.Image;
                    pictureBox2.Image = pictureBox1.Image;
                    pictureBox1.Image = null;
                    break;
            }
            isFirstOne = !isFirstOne;
        }
    }
