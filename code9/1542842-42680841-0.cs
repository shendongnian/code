     while(Connected == false)
                {
                    byte[] data = new byte[1024];
                    int size = networkStream.Read(data, 0, data.Length);
                    recieved = Encoding.ASCII.GetString(data, 0, size);
                    Console.WriteLine(recieved);
                     if (recieved.Contains("login"))
                            {
                                 login = string.Format("{0}\r\n",user);
                                 Console.WriteLine("user request found:{0}", login);
                            }
                     else if (recieved.Contains("password"))
                     {
                         login = string.Format("{0}\r\n",pass);
                         Console.WriteLine("password request found:{0}", login);
                     }
                     else if (recieved.Contains("GNET"))
                     {
                         Console.WriteLine(recieved);
                         Connected = true;
                     }
                     byte[] loginBuffer = Encoding.ASCII.GetBytes(login);
                     networkStream.Write(loginBuffer, 0, loginBuffer.Length);
                     networkStream.Flush();
                }
