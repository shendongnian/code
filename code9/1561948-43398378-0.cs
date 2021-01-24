     netTcpBinding = new NetTcpBinding
                                {
                                    MaxReceivedMessageSize = int.MaxValue,
                                    MaxBufferPoolSize = int.MaxValue,
                                    Security = new NetTcpSecurity
                                               {
                                                   Mode = SecurityMode.None,
                                                   Transport = new TcpTransportSecurity()
                                               }
                                };
