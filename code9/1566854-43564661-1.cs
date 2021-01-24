                                Socket serverSocket = tcpServerListener.AcceptSocket();
                                NetworkStream serverSocketStream = new NetworkStream(serverSocket);
                                Console.WriteLine("SERVER");
                                tcpServerListener.Start();
                                Console.WriteLine("[connected to client]");
                                byte[] byt = new byte[1024];
                                //get size Lenght
                                int Lenght = Convert.ToInt32(sr.ReadLine());
                                byte[] byt_2 = new byte[Lenght + 3000];
                                Console.WriteLine("-");
                                // Get The File
                                serverSocketStream.Read(byt_2, 0, byt_2.Length);
                                Console.WriteLine("-");
                                Console.WriteLine("write bytes");
                                //write bytes in the file
                                File.WriteAllBytes(@"c:\users\jakob\desktop\bild1.jpg", byt_2);
