      byte[] byt = System.Text.Encoding.ASCII.GetBytes("sRN DItype");
                        stream.Write(STX, 0 , 1);
                        stream.Write(byt, 0, byt.Length);
                        stream.Write(ETX, 0, 1);
                            stream.Read(buffer, 0, buffer.Length);
