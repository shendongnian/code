                                    TcpClient tcpClient = new TcpClient(ip, 2000);
                                    NetworkStream clientSockStream = tcpClient.GetStream();
                                    Console.WriteLine("connecting to server");
                                    StreamWriter clientStreamWriter = new StreamWriter(clientSockStream);
                                    Console.WriteLine("send data");
                                    //-
                                    Bitmap b = new Bitmap(SystemInformation.VirtualScreen.Width, SystemInformation.VirtualScreen.Height);
                                    Graphics g = Graphics.FromImage(b);
                                    Console.WriteLine("taking screenshot");
                                    g.CopyFromScreen(0, 0, 0, 0, b.Size);
                                    g.Dispose();
                                    MemoryStream ms = new MemoryStream();
                                    b.Save(ms, ImageFormat.Png);
                                    byte[] bmp = ms.ToArray();
                                    // Send the file size
                                    sw.WriteLine(bmp.Length);
                                    // Send the file
                                    clientSockStream.Write(bmp, 0, bmp.Length);
                                    //-
                                    tcpClient.Close();
