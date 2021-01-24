    Byte[] data;
    
                    using (FileStream fs = new FileStream(fileNameWitPath, fileMode))
                    {
                        using (BinaryWriter bw = new BinaryWriter(fs))
                        {
                            //get co-ords
                            int x1 = Convert.ToInt32(context.Request.QueryString["x1"].Trim());
                            int y1 = Convert.ToInt32(context.Request.QueryString["y1"].Trim());
                            int x2 = Convert.ToInt32(context.Request.QueryString["x2"].Trim());
                            int y2 = Convert.ToInt32(context.Request.QueryString["y2"].Trim());
    
                            Bitmap b = new Bitmap(fs);
                            Bitmap nb = new Bitmap((x2 - x1), (y2 - y1));
                            Graphics g = Graphics.FromImage(nb);
                            //g.DrawImage(b, x2, y2);
                            Rectangle cropRect = new Rectangle(x1, y1, nb.Width, nb.Height);
    
                            g.DrawImage(b, new Rectangle(0, 0, nb.Width, nb.Height), cropRect, GraphicsUnit.Pixel);
                            
                            using (var memoryStream = new MemoryStream())
                            {
                                nb.Save(memoryStream, ImageFormat.Png);
                                data = memoryStream.ToArray();
                            }
    
                            bw.Close();
                        }
                    }
    
                    using (FileStream fs = new FileStream(fileNameWitPath, fileMode))
                    {
                        using (BinaryWriter bw = new BinaryWriter(fs))
                        {
                            bw.Write(data);
                            bw.Close();
                        }
                    }
