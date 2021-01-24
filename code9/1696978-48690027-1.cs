            //string s1 = Encoding.UTF8.GetString(data);
            int port = 30718;
            string Antwort;
            // Socket definieren
            Socket bcSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            //bcSocket.Connect(new IPEndPoint(IPAddress.Broadcast, port));
            // EndPoint definieren bzw. Ziel des Broadcastes
            IPEndPoint iep = new IPEndPoint(IPAddress.Broadcast, port);
            // Optionen auf den Socket binden
            bcSocket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.Broadcast, 1);
            // Broadcast senden
            bcSocket.SendTo(data, iep);
           
            bcSocket.ReceiveTimeout = 5000;
            byte[] test = new byte[1024];
            IPEndPoint _sender = new IPEndPoint(IPAddress.Any, 0);
            EndPoint senderRemote = (EndPoint)_sender;
            bcSocket.ReceiveFrom(test, ref senderRemote); //IP steht in senderRemote! / IP is in senderRemote!
            Antwort = System.Text.Encoding.Default.GetString(test).Trim(new char[] { '\0' });
            textBox_IPAdresse.Text = senderRemote.ToString(); //Ausgabe der RemoteIP
            string antworthex = BitConverter.ToString(test);
            textBox1.Text = antworthex;
            
            // Socket schliessen, nach erfolgreichem Senden des Broadcastes
            bcSocket.Close();
