    private async void StartClient()
        {
            String sName = "<server ip>";
            int port = <server port>;
            
            WaveOut waveout = new WaveOut(); 
            TcpClient conn = new TcpClient();
            
            try
            {
                int counter = 0;
                conn.Connect(sName, port);
                stream = conn.GetStream();               
                by = new byte[2560];  // new byte array to store received data
               
                var bufferedWaveProvider = new BufferedWaveProvider(new WaveFormat(16000, 16, 2));
                bufferedWaveProvider.BufferLength = 2560 * 16;      //16 is pretty good
                bufferedWaveProvider.DiscardOnBufferOverflow = true;
                while (true)
                {
                    //wait until buffer has data, then returns buffer length
                    int bytesAvailable = await stream.ReadAsync(by, 0, 2560);
                    if (counter == 0)
                    {
                        msg = Encoding.UTF8.GetString(by, 0, bytesAvailable);
                        devicehash = msg.TrimEnd();
                        DispatchMethod(by[0].ToString());
                        counter++;                        
                    }
                    else
                    {
                        //send to speakers
                        bufferedWaveProvider.AddSamples(by, 0, 2560);
                        if (counter == 1)
                        {
                            waveout.Init(bufferedWaveProvider);
                            waveout.Play();
                            counter++;
                        }                     
                    }
                }
            }
            catch (Exception e)
            { 
            }
        }
