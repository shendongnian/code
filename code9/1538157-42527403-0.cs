    using System;
    using System.IO;
    using System.Drawing;
    using System.Windows.Forms;
    
    namespace BlendSlideShow
    {
        public partial class Form1 : Form
        {
            private float mBlend;
            private int mDir = 1;
            public int count = 0;
            public Bitmap[] pictures;
    
            public Form1()
            {
                InitializeComponent();
    
                pictures = new Bitmap[9];
                pictures[0] = new Bitmap(GetImgFolderPath() + "img1.jpg");
                pictures[1] = new Bitmap(GetImgFolderPath() + "img2.jpg");
                pictures[2] = new Bitmap(GetImgFolderPath() + "img3.jpg");
                pictures[3] = new Bitmap(GetImgFolderPath() + "img4.jpg");
                pictures[4] = new Bitmap(GetImgFolderPath() + "img5.jpg");
                pictures[5] = new Bitmap(GetImgFolderPath() + "img6.jpg");
                pictures[6] = new Bitmap(GetImgFolderPath() + "img7.jpg");
                pictures[7] = new Bitmap(GetImgFolderPath() + "img8.jpg");
                pictures[8] = new Bitmap(GetImgFolderPath() + "img9.jpg");
    
                timer1.Interval = 50; //time of transition
                timer1.Tick += BlendTick;
                try
                {
                    blendPanel1.Image1 = pictures[count];
                    blendPanel1.Image2 = pictures[++count];
                }
                catch
                {
    
                }
                timer1.Enabled = true;
            }
    
            private string GetImgFolderPath()
            {
                string _Path = Path.GetDirectoryName(Application.ExecutablePath) + @"\..\..\images\";
                return _Path;
            }
    
            int numberOfTicks;
            int ticksBeforeBlendStarts = 100;
    
            private void BlendTick(object sender, EventArgs e)
            {
                if (numberOfTicks >= ticksBeforeBlendStarts)
                {
                    mBlend += mDir * 0.02F;
                    if (mBlend > 1)
                    {
                        mBlend = 0.0F;
                        if ((count + 1) < pictures.Length)
                        {
                            blendPanel1.Image1 = pictures[count];
                            blendPanel1.Image2 = pictures[++count];
                        }
                        else
                        {
                            blendPanel1.Image1 = pictures[count];
                            blendPanel1.Image2 = pictures[0];
                            count = 0;
                        }
    
                        numberOfTicks = 0;
                    }
                    blendPanel1.Blend = mBlend;
                }
                numberOfTicks++;
            }
        }
    }
