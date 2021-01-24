                                    Bitmap b = new Bitmap(SystemInformation.VirtualScreen.Width, SystemInformation.VirtualScreen.Height);
                                    Graphics g = Graphics.FromImage(b);
                                    Console.WriteLine("taking screenshot");
                                    g.CopyFromScreen(0, 0, 0, 0, b.Size);
                                    g.Dispose();
                                    
                                    b.Save(ms, ImageFormat.Png);
                                    byte[] bmp = ms.ToArray();
                                    string kl = Convert.ToString(bmp);
                                    // Send the file size
                                    Char[] ch = new Char[bmp.Length]; //added
                                    clientSockStream.Write(Encoding.ASCII.GetBytes(ch), 0,Encoding.ASCII.GetByteCount(ch));
                                    // Send the file:
                                    clientSockStream.Write(bmp, 0, bmp.Length);
