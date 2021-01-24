    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication3
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
                this.pictureBox1.Paint += new PaintEventHandler(this.pictureBox1_Paint);
            }
    
            // Opens an image file
            // and runs "FindBounds()" method
            private void openToolStripMenuItem_Click(object sender, EventArgs e)
            {
                OpenFileDialog dlg = new OpenFileDialog();
                if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    this.image = Image.FromFile(dlg.FileName) as Bitmap;
                    FindBounds();
                    this.pictureBox1.Image = image;
                    this.pictureBox1.Invalidate();
                }
            }
    
            Bitmap image;
    
            // Possible maximum side of a spot or a dot in the image
            int maxSpotOrDotSide = 7;
    
            // Finds top, left, right and bottom bounds of the content in TIFF file.
            private void FindBounds()
            {
                // Possible maximum area of a spot or a dot in the image
                int maxSpotOrDotArea = maxSpotOrDotSide * maxSpotOrDotSide;
    
                this.left = 0;
                this.top = 0;
                this.right = this.pictureBox1.Width - 1;
                this.bottom = this.pictureBox1.Height - 1;
    
                int h = image.Height;
                int w = image.Width;
                int num = w * h;
    
                // Incrementers. I tested with greater values
                // like "x = 2", "x = 5" and it increased performance.
                // But we must be carefull as this may cause skipping content.
                int dx = 1; // Incrementer for "x"
                int dy = 1; // Incrementer for "y"
    
                // Initialization of "progressBar1"
                this.progressBar1.Value = 0;
                this.progressBar1.Maximum = num;
    
                // Content of the image
                BlackContent imageContent = null;
    
                // Here we will scan pixels of the image
                // starting from top left corner and 
                // finishing at bottom right
                for (int y = 0; y < h; y += dx)
                {
                    for (int x = 0; x < w; x += dy)
                    {
                        int val = y * w + x;
                        this.progressBar1.Value = val > num ? num : val;
                        // This block skips scanning imageContent
                        // thus should increase performance.
                        if (imageContent != null && imageContent.Contains(x, y))
                        {
                            x = imageContent.Right;
                            continue;
                        }
    
                        // Interesting things begin to happen
                        // after we detect the first Black pixel
                        if (this.image.GetPixel(x, y).ToArgb() == Black)
                        {
                            BlackContent content = new BlackContent(x, y);
                            // Start Flood-Fill algorithm
                            content.FloodFill(this.image);
                            if (content.Area > maxSpotOrDotArea)
                            {
                                if (imageContent == null)
                                {
                                    imageContent = content;
                                }
                                imageContent.Include(content.Right, content.Bottom);
                                imageContent.Include(content.Left, content.Top);
                            }
                            else
                            {
                                // Here it's better we increase values of the incrementers.
                                // Depending on size of spots/dots.
                                // It should increase performance.
                                if (dx < content.Width) dx = content.Width;
                                if (dy < content.Height) dy = content.Height;
                            }
                        }
    
                    }
                }
    
                // Everything is done.
                this.progressBar1.Value = this.progressBar1.Maximum;
    
                // If image content has been detected 
                // then we save the information
                if (imageContent != null)
                {
                    this.left = imageContent.Left;
                    this.top = imageContent.Top;
                    this.right = imageContent.Right;
                    this.bottom = imageContent.Bottom;
                }
    
                this.pictureBox1.Invalidate();
            }
    
            internal static readonly int Black = Color.Black.ToArgb();
            internal static readonly int White = Color.White.ToArgb();
    
            int top;
            int bottom;
            int left;
            int right;
    
            private void pictureBox1_Paint(object sender, PaintEventArgs e)
            {
                if (pictureBox1.Image == null)
                {
                    return;
                }
    
                int xMax = pictureBox1.Image.Width;
                int yMax = pictureBox1.Image.Height;
    
                int startX = this.left;
                int startY = this.top;
                int endX = this.right;
                int endY = this.bottom;
    
    
                int picWidth = pictureBox1.Size.Width;
                int picHeight = pictureBox1.Size.Height;
    
    
                float imageRatio = xMax / (float)yMax; // image W:H ratio
                float containerRatio = picWidth / (float)picHeight; // container W:H ratio
    
                if (imageRatio >= containerRatio)
                {
                    // horizontal image
                    float scaleFactor = picWidth / (float)xMax;
                    float scaledHeight = yMax * scaleFactor;
                    // calculate gap between top of container and top of image
                    float filler = Math.Abs(picHeight - scaledHeight) / 2;
                    //float filler = 0;
    
                    startX = (int)(startX * scaleFactor);
                    endX = (int)(endX * scaleFactor);
                    startY = (int)((startY) * scaleFactor + filler);
                    endY = (int)((endY) * scaleFactor + filler);
                }
                else
                {
                    // vertical image
                    float scaleFactor = picHeight / (float)yMax;
                    float scaledWidth = xMax * scaleFactor;
                    float filler = Math.Abs(picWidth - scaledWidth) / 2;
                    startX = (int)((startX) * scaleFactor + filler);
                    endX = (int)((endX) * scaleFactor + filler);
                    startY = (int)(startY * scaleFactor);
                    endY = (int)(endY * scaleFactor);
                }
    
                //if (_once)
                //Rectangle ee = new Rectangle(35, 183, 405, 157);
                Rectangle ee = new Rectangle(startX, startY, endX - startX, endY - startY);
                System.Diagnostics.Debug.WriteLine(startX + ", " + startY + ", " + (endX - startX) + ", " + (endY - startY));
                using (Pen pen = new Pen(Color.Red, 2))
                {
                    e.Graphics.DrawRectangle(pen, ee);
                }
                //_once = false;
            }
        }
    
        // This class is similar to System.Drawing.Region class
        // except that its only rectangular. 
        // Because all we need is to draw a rectagnle
        // around the image this property must 
        // make it faster, at least I hope so.
        
        class BlackContent
        {
            internal void FloodFill(Bitmap image)
            {
                FloodFillPrivate(image, this.left + 1, this.top, 0);
            }
    
            // Legendary Flood-Fill algorithm.
            // Quite often it ends up with StackOverFlow exception.
            // But this class and its rectangularity property
            // must prevent this disaster.
            // In my experiments I didn't encounter incidents.
            void FloodFillPrivate(Bitmap image, int x, int y, int level)
            {
                if (x >= image.Width || x < 0 || y >= image.Height || y < 0 || this.Contains(x, y) || image.GetPixel(x, y).ToArgb() != Form1.Black)
                {
                    return;
                }
    
                this.Include(x, y);
    
                FloodFillPrivate(image, x, y - 1, level + 1);
                FloodFillPrivate(image, x, y + 1, level + 1);
                FloodFillPrivate(image, x - 1, y, level + 1);
                FloodFillPrivate(image, x + 1, y, level + 1);
            }
    
            internal BlackContent(int x, int y)
            {
                this.left = x;
                this.right = x;
                this.top = y;
                this.bottom = y;
            }
    
            internal void Include(int x, int y)
            {
                if (x < this.left)
                {
                    this.left = x;
                }
                if (this.right < x)
                {
                    this.right = x;
                }
                if (this.bottom < y)
                {
                    this.bottom = y;
                }
                if (y < this.top)
                {
                    this.top = y;
                }
            }
    
            internal bool Contains(int x, int y)
            {
                return !(x < this.left || x > this.right || y < this.top || y > this.bottom);
            }
    
            int left;
            internal int Left { get { return this.left; } }
            int top;
            internal int Top { get { return this.top; } }
            int right;
            internal int Right { get { return this.right; } }
            int bottom;
            internal int Bottom { get { return this.bottom; } }
    
            internal int Area
            {
                get
                {
                    return Width * Height;
                }
            }
    
            internal int Width
            {
                get
                {
                    return (this.right - this.left + 1);
                }
            }
    
            internal int Height
            {
                get
                {
                    return (this.bottom - this.top + 1);
                }
            }
        }
    
    }
