    private static void ReturnManager(Socket Soc)
        {
            //Thread.Sleep(100);
            using (StreamReader RS = new StreamReader(new NetworkStream(Soc)))
            {
                DateTime TMR = DateTime.Now;
                while (true)
                {
                    while (RS.Peek() > 0 | Soc.Available > 0)
                    {
                        Console.WriteLine(RS.ReadLine());
                        TMR = DateTime.Now;
                    }
                    if(DateTime.Now - TMR > TimeSpan.FromSeconds(LastReadTimeoutSeconds))
                    {
                        try
                        {
                            if (!Soc.Connected) break;
                            else
                            {
                                Soc.Send(new byte[1] { 255 });//Verify that the Server is still keeping the Socket open thus the command is still active
                                TMR = DateTime.Now;
                            }
                        }
                        catch
                        {
                            break;
                        }
                    }
                }
            }
            Soc.Close();
            Soc.Dispose();
        }
