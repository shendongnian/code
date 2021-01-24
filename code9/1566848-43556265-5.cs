                        serverSocketStream.Read(byt, 0, 1024); // Get the file size
                        byte[] byt_2 = new byte[Convert.ToInt32(System.Text.Encoding.UTF8.GetString(byt)) + 300];
                        Console.WriteLine("-");
                        serverSocketStream.Read(byt_2, 0, byt_2.Length); // Get The File
                        Console.WriteLine("-");
                        Console.WriteLine("write bytes");
                        File.WriteAllBytes(@"c:\users\jakob\desktop\bild1.jpg", byt_2);
