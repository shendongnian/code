    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication2
    {
        public partial class Form1 : Form
        {
            Image img1;
            Image img2;
            public Form1()
            {
                InitializeComponent();
    
                Image img = Image.FromFile(@"C:\pics\1.jpg");
                this.btnImage.Image = img;
                this.pcitureBox.AllowDrop = true;                
            }
    
            private void btnImage_MouseDown(object sender, MouseEventArgs e)
            {
                Button btnPic = (Button)sender;
                btnPic.DoDragDrop(btnPic.Image, DragDropEffects.Copy);
            }
    
            private void picBox_DragEnter(object sender, DragEventArgs e)
            {
                if (e.Data.GetDataPresent(DataFormats.Bitmap))
                {
                    e.Effect = DragDropEffects.Copy;
                }
                else
                {
                    e.Effect = DragDropEffects.None;
                }
            }
    
            int img1X = 0;
            int img1Y = 0;
            private void picBox_DragDrop(object sender, DragEventArgs e)
            {
                var point = this.PointToClient(new Point(e.X, e.Y));
                int X = point.X - pcitureBox.Left;
                int Y = point.Y - pcitureBox.Top;
    
                
    
                    PictureBox picbox = (PictureBox)sender;
                    Graphics g = picbox.CreateGraphics();
                    if (img1 == null)
                    {
                        img1 = (Image)e.Data.GetData(DataFormats.Bitmap);
                        img1X=X;
                        img1Y = Y;
                        g.DrawImage(img1, new Point(img1X, img1Y));
                        
                        return;
                    }
                    else
                    {
                        #region add img2
                        img2 = (Image)e.Data.GetData(DataFormats.Bitmap);
    
                        //img1 has standart 0,0 point u can change
                        Rectangle r1 = new Rectangle(img1X, img1Y,     img1.Width, img1.Height);
                        Rectangle r2 = new Rectangle(X, Y, img2.Width,   img2.Height);
                        Rectangle overlapRect = Rectangle.Intersect(r1, r2);
    
                        int img2X = X;
                        int img2Y = Y;
                        if (overlapRect.Width > 0 || overlapRect.Height > 0)
                        {
                            bool betweenX = overlapRect.X >= r1.X &&         overlapRect.X <= (r1.X + r1.Height);
                            bool betweenY = overlapRect.Y >= r1.Y &&     overlapRect.Y <= (r1.Y + r1.Width);
    
                            if (betweenX)
                            {
                                img2X = GetNewX(r1, r2);
                            }
                            else if (betweenY)
                            {
                                img2Y = GetNewY(r1, r2);
                            }
                            else
                            {
                                if (overlapRect.Width <= overlapRect.Height)
                                {
                                    img2X = GetNewX(r1, r2);
                                }
                                else
                                {
                                    img2Y = GetNewY(r1, r2);
                                }
                            }
                        }
                        g.DrawImage(img1, new Point(img2X, img2Y));
                        #endregion
                    }
              
            }
    
            private int GetNewX(Rectangle r1, Rectangle r2)
            {
                if (r2.X < r1.X)
                {
                    return r1.X - r2.Width;
                }
                else
                {
                    return r1.X + r1.Width;
                }
            }
            private int GetNewY(Rectangle r1, Rectangle r2)
            {
                if (r2.Y < r1.Y)
                {
                    return r1.Y - r2.Height;
                }
                else
                {
                    return r1.Y + r1.Height;
                }
            }
    
        }
    }
    
