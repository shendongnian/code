    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using System.IO;
    using System.Drawing.Imaging;
    public partial class Form1 : Form
    {
        private int[] size = new int[5] { 36, 24, 48, 72, 96 };
        private Bitmap one, two, three, four, five;
        private string[] path = new string[5] { "drawable-hdpi-", "drawable-mdpi-", "drawable-xhdpi-", "drawable-xxhdpi-", "drawable-xxxhdpi-" };
        public Form1()
        {
            InitializeComponent();
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            DialogResult result = this.openFileDialog1.ShowDialog();
            // if a file is selected
            if (result == DialogResult.OK)
            {
                // Set the selected file URL to the textbox
                this.textBox1.Text = this.openFileDialog1.FileName;
            }
        }
        private void Button2_Click(object sender, EventArgs e)
        {
            if (!this.textBox1.Text.Equals(""))
            {
                Resize(this.textBox1.Text, getFileName(this.textBox1.Text));
            }
            else
            {
                MessageBox.Show("Nessun file selezionato");
            }
        }
        private string getFileName(string text)
        {
            return Path.GetFileName(text) ;
        }
        private new void Resize(string text, string name)
        {
            Bitmap bitmap = new Bitmap(text);
            one = bitmap;
            two = bitmap;
            three = bitmap;
            four = bitmap;
            five = bitmap;
            one = ResizeImage(one, size[0], size[0]);
            two = ResizeImage(two, size[1], size[1]);
            three = ResizeImage(three, size[2], size[2]);
            four = ResizeImage(four, size[3], size[3]);
            five = ResizeImage(five, size[4], size[4]);
            SaveImage(one, two, three, four, five, name);
        }
   
    private void SaveImage(Bitmap one, Bitmap two, Bitmap three, Bitmap four, Bitmap five, string name)
        {
            DialogResult folder = folderBrowserDialog1.ShowDialog();
            if (folder == DialogResult.OK && !string.IsNullOrWhiteSpace(folderBrowserDialog1.SelectedPath))
            {
                SaveIn(one, Path.Combine(folderBrowserDialog1.SelectedPath,  path[0]+ name));
                SaveIn(two,  Path.Combine(folderBrowserDialog1.SelectedPath , path[1] + name));
                SaveIn(three,  Path.Combine(folderBrowserDialog1.SelectedPath , path[2]+name));
                SaveIn(four, Path.Combine(folderBrowserDialog1.SelectedPath , path[3] +name));
                SaveIn(five, Path.Combine(folderBrowserDialog1.SelectedPath , path[4] + name));
            CleanBmp(one);
            CleanBmp(two);
            CleanBmp(three);
            CleanBmp(four);
            CleanBmp(five);
        }
        }
    private void CleanBmp(Bitmap bmp)
    {
        bmp.Dispose();
        bmp = null;
    }
    private void SaveIn(Bitmap bmp, string v)
        {
            try
            {
            Bitmap newBitmap = new Bitmap(bmp);
            
            newBitmap.Save(v);
            CleanBmp(newBitmap);
        }
            catch (Exception exc)
            {
                MessageBox.Show("" + exc);
            }
        }
        public Bitmap ResizeImage(Bitmap image, int newWidth, int newHeight)
        {
            try
            {
                Bitmap newImage = new Bitmap(newWidth, Calculations(image.Width, image.Height, newWidth));
                using (Graphics gr = Graphics.FromImage(newImage))
                {
                    gr.SmoothingMode = SmoothingMode.AntiAlias;
                    gr.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    gr.PixelOffsetMode = PixelOffsetMode.HighQuality;
                    gr.DrawImage(image, new Rectangle(0, 0, newImage.Width, newImage.Height));
                    var myBrush = new SolidBrush(Color.FromArgb(70, 205, 205, 205));
                    double diagonal = Math.Sqrt(newImage.Width * newImage.Width + newImage.Height * newImage.Height);
                    float slope = (float)(Math.Atan2(newImage.Height, newImage.Width) * 180 / Math.PI);
                    gr.RotateTransform(slope);
                    return newImage;
                }
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }
        public int Calculations(decimal w1, decimal h1, int newWidth)
        {
            decimal height = 0;
            decimal ratio = 0;
            if (newWidth < w1)
            {
                ratio = w1 / newWidth;
                height = h1 / ratio;
                return (int)height;
            }
            if (w1 < newWidth)
            {
                ratio = newWidth / w1;
                height = h1 * ratio;
                return (int)height;
            }
            return (int)height;
        }
    }
