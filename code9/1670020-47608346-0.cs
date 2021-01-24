                        using (Bitmap b = new Bitmap(Image.FromFile(System.Web.HttpContext.Current.Server.MapPath("~/IncomingData/" + ImageFileName))))
                        {
                            b.MakeTransparent(Color.White);
                            iTextSharp.text.Image savedImage = iTextSharp.text.Image.GetInstance(b, System.Drawing.Imaging.ImageFormat.Png);
                            savedImage.SetAbsolutePosition(Convert.ToSingle(x + 1.0), Convert.ToSingle(imageY + 12) - Convert.ToSingle(h));
                            savedImage.ScaleToFit(Convert.ToSingle(w), Convert.ToSingle(h));
                            
                            contentByte.AddImage(savedImage);
                        }
