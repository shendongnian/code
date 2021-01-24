     bytes = new byte[1024];
                try
                {
                    ipAddress = IPAddress.Parse("192.168.0.128");
                    remoteEP = new IPEndPoint(ipAddress, 11000);
                    sender = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    try
                    {
                        string toSend = TextBox1.Text;
    
                        sender.Connect(remoteEP);
                        //sending
                        int toSendLen = System.Text.Encoding.ASCII.GetByteCount(toSend);
                        byte[] toSendBytes = System.Text.Encoding.ASCII.GetBytes(toSend);
                        byte[] toSendLenBytes = System.BitConverter.GetBytes(toSendLen);
                        //Console.WriteLine("Soccket connected to{0}", sender.RemoteEndPoint.ToString());
                        sender.Send(toSendLenBytes);
                        sender.Send(toSendBytes);
    
                        //Receiving
    
                        byte[] rcvLenBytes = new byte[4];
                        sender.Receive(rcvLenBytes);
                        int rcvLen = System.BitConverter.ToInt32(rcvLenBytes, 0);
                        byte[] rcvBytes = new byte[rcvLen];
                        sender.Receive(rcvBytes);
                        String rcv = System.Text.Encoding.ASCII.GetString(rcvBytes);
                        TextBox1.Text = rcv;
    
    
                        //----------------OLD----------------------------
                        //  byte[] msg = Encoding.ASCII.GetBytes("This is some Test.");
                        //  TextBox1.Text = msg.ToString();
                        //  int byteSent = sender.Send(msg);
                        //  TextBox1.Text += "Bytes Sent = " + byteSent;
    
                        ////  System.Threading.Tasks.Task.Delay(1000).Wait();
                        //  int byteRec = sender.Receive(bytes);
                        //  string messageRec = Encoding.ASCII.GetString(bytes, 0, byteRec);
                        //  Console.WriteLine("Response from remote Device {0}", messageRec);
                        //  TextBox1.Text += "\nmessageRec = " + messageRec;
                        sender.Shutdown(SocketShutdown.Both);
                        sender.Close();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
                catch (Exception m)
                {
                    Console.WriteLine(m.Message);
                }
