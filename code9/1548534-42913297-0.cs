     Socket socket = TcpClient.Client;
                                        string UserTest = "" + Username;
                                        try
                                        { // sends the text with timeout 10s
                                            UserInfo.Send(socket, Encoding.UTF8.GetBytes(UserTest), 0, UserTest.Length, 1000000);
                                        }
                                        catch (Exception ex) { /* ... */ }
