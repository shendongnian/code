            var stopEvent = new ManualResetEvent(false);
            var thread = new Thread(() => {
                if (!serialPort1.isOpen)
                {
                    serialPort1.Open();
                }
                try
                {
                    while (!stopEvent.WaitOne(0))
                    {
                        try
                        {
                            serialPort1.WriteLine("INFO");
                            string data = serialPort1.ReadLine();
                            Invoke((MethodInvoker)(() => editData(data)));
                        }
                        catch (Exception)
                        {
                            // Handle exception, e.g. a reading timeout
                        }
                        
                        stopEvent.WaitOne(1000); //Thread.Sleep(1000);
                    }
                } finally
                {
                    serialPort.Close();
                }
            });
            thread.Start();
            //call it to stop the loop.
            stopEvent.Set();
        }
