    foreach (UnicastIPAddressInformation ip in net.GetIPProperties().UnicastAddresses)
                                {
                                    if (ip.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                                    {
                                        Console.WriteLine(ip.Address.ToString() + " " + net.Description);
                                        Console.ReadKey();
                                    }
                                }
