                        Bitmap b = new Bitmap(SystemInformation.VirtualScreen.Width, SystemInformation.VirtualScreen.Height);
                        Graphics g = Graphics.FromImage(b);
                        Console.WriteLine("taking screenshot");
                        g.CopyFromScreen(0, 0, 0, 0, b.Size);
                        g.Dispose();
                        MemoryStream ms = new MemoryStream();
                        b.Save(ms, ImageFormat.Png);
                        byte[] bmp = ms.ToArray();
                        // Send the file size
                        clientSockStream.Write(Encoding.ASCII.GetBytes(bmp.Length), 0, Encoding.ASCII.GetBytes(bmp.Length).Length);
                       // Send the file:
                     
                       clientSockStream.Write(bmp, 0, bmp.Length);
                       
