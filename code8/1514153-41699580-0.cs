            String address = "00:00:00:00:00:00";
            Guid mUUID = new Guid("00000000-0000-0000-0000-0000500b34fb");
            BluetoothAddress addr = BluetoothAddress.Parse(address);
            var btEndpoint = new BluetoothEndPoint(addr, mUUID);
            var btClient = new BluetoothClient();
            btClient.connect(btEndpoint);
            using (Stream peerStream = btClient.GetStream())
            using (StreamWriter sw = new StreamWriter(peerStream))
            {
                sw.WriteLine("Send command");
                sw.Flush();
                if (peerStream.CanRead)
                {
                    using (StreamReader sr = new StreamReader(peerStream))
                    {
                        while (sr.Peek() >= 0)
                        {
                            Debug.WriteLine("Receive data" + sr.ReadLine());
                        }
                    }
                }
            }
