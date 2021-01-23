            string match = "68656C6C6F";
            byte[] matchBytes = Encoding.ASCII.GetBytes(match);
            foreach (var jsFile in jsscan)
            {
                using (var fs = new FileStream(jsFile, FileMode.Open))
                {
                    int i = 0;
                    int readByte;
                    while ((readByte = fs.ReadByte()) != -1)
                    {
                        if (matchBytes[i] == readByte)
                        {
                            i++;
                        }
                        else
                        {
                            i = 0;
                        }
                        if (i == matchBytes.Length)
                        {
                            Console.WriteLine("It found between {0} and {1}.", fs.Position - matchBytes.Length, fs.Position);
                            break;
                        }
                    }
                }
            }
