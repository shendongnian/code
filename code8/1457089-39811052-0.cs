      List<byte> total = new List<byte>(File.ReadAllBytes(System.Reflection.Assembly.GetEntryAssembly().Location));
                    byte[] totalByteArray = total.ToArray(); 
                    int OwnSize = 115200;//Size of you exe file without checksum
                    int Md5Length = BitConverter.ToInt32(totalByteArray, OwnSize+4);
                    string NormalFileNameString = Encoding.ASCII.GetString(totalByteArray, OwnSize, Md5Length);
