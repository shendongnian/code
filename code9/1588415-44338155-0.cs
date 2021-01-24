     static byte[] Receive(NetworkStream netstr)
            {
                try
                {
                    // Buffer to store the response bytes.
                    byte[] recv = new Byte[256];
    
                    // Read the first batch of the TcpServer response bytes.
                    int bytes = netstr.Read(recv, 0, recv.Length); //(**This receives the data using the byte method**)
    
                    byte[] a = new byte[bytes];
    
                    for(int i = 0; i < bytes; i++)
                    {
                        a[i] = recv[i];
                    }
    
                    return a;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error!\n" + ex.Message + "\n" + ex.StackTrace);
    
                    return null;
                }
    
            }
    
            static void Send(NetworkStream netstr, byte[] message)
            {
                try
                {
                    //byte[] send = Encoding.UTF8.GetBytes(message.ToCharArray(), 0, message.Length);
                    netstr.Write(message, 0, message.Length);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error!\n" + ex.Message + "\n" + ex.StackTrace);
                }
            }
