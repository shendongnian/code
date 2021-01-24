     Form f = new Form();
                f.FormClosed += (se, ev) => {
                    Rectangle bounds = f.Bounds; //Important to set the bounds of the Form you want to screenshot
                    using (Bitmap bitmap = new Bitmap(bounds.Width, bounds.Height))
                    {
                        using (Graphics g = Graphics.FromImage(bitmap))
                        {
                            g.CopyFromScreen(new Point(bounds.Left, bounds.Top), Point.Empty, bounds.Size);
                        }
                        bitmap.Save("screenshot.png", ImageFormat.Jpeg);
                    }
                };
                f.Show();
                System.Threading.Thread.Sleep(2000);
    
                f.Close();
