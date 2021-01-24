    private void Listen()
        {
            while (!_stopping)
            {
                try
                {
                    var asyncResult = MyUdpClient.BeginReceive(HandleIncomingUdpRequest, null);
                    WaitHandle.WaitAny(new[] { _stopHandle, asyncResult.AsyncWaitHandle });
                }
                catch (Exception ex)
                {
                    using (var sw = new StreamWriter("log.txt"))
                    {
                        sw.WriteLine("Date:" + DateTime.Now + "\r\nError:" + ex.Message + "\r\n");
                    }
                }
                MyUdpClient.Close();
            }
        }
