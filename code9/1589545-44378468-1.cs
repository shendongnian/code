        // Capture handler
        private void timer2_Tick(object sender, EventArgs e)
        {
            // Read data from serial port, poll every 10ms
            // If data is there, read a block and write it to array
            int bytestoread = 0;
            //byte buf;
            timer2.Stop();
            try
            {
                bytestoread = serialPort1.BytesToRead;
            }
            catch (InvalidOperationException ex)
            {
                tbr.Append("Serial connection lost. Exception type:" + ex.ToString());
                if ((uint)ex.HResult == 0x80131509)
                {
                    timer2.Stop();
                }
            }
            if (serialPort1.IsOpen)
            {
                if (bytestoread != 0)
                {
                    bytespersecond += bytestoread;
                    byte[] temp = new byte[bytestoread];
                    if (serialPort1.IsOpen)
                        serialPort1.Read(temp, 0, bytestoread);
                    tempbuffer.Add(temp);
                    processing.indexrxbuf += bytestoread;
                    recentreadbuflength += bytestoread;
                    //update the scatterplot, this may have a performance hit
                    processing.rxbuf = tempbuffer.SelectMany(a => a).ToArray();
                    rxbuf = processing.rxbuf;
                    if (Setrxbufcontrol == null) return;
                    Setrxbufcontrol();
                }
                timer2.Start();
            }
        }
