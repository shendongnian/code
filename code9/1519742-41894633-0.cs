                for (int i = 0; i < 255; i++)
                {
                    using (System.Net.NetworkInformation.Ping pingSender = new System.Net.NetworkInformation.Ping())
                    {
                        //textbox.text example: 10.20.18.
                        //i = 0 > 255
                        targetIP[i] = textBox2.Text + i;
                        //send ping
                        PingReply reply = pingSender.Send(targetIP[i], timeout, buffer, options);
                        //if reply is successfull
                        if (reply.Status == IPStatus.Success)
                        {
                            textBox1.AppendText("Address: " + reply.Address + "\t ms: " + reply.RoundtripTime + "\n");
                        }
                    }
