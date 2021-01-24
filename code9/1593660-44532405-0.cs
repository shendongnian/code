        private void receive() {
            try {
                while(running) {
                    if(clientSocket.Available>=4) {
                        // receive header bytes from tcp stream
                        byte[] header = new byte[4];
                        clientSocket.Receive(header, 4, SocketFlags.None);
                        int bytesToRead = BitConverter.ToInt32(header, 0);
                        // receive body bytes from tcp stream
                        int offset = 0;
                        byte[] data = new byte[bytesToRead];
                        while(bytesToRead > 0) {
                            int bytesReceived = clientSocket.Receive(data, offset, bytesToRead, SocketFlags.None);
                            offset += bytesReceived;
                            bytesToRead -= bytesReceived;
                        }
                        // deserialize byte array to network packet
                        NetworkPacket packet = null;
                        using(MemoryStream ms = new MemoryStream(data)) {
                            BinaryFormatter bf = new BinaryFormatter();
                            packet = (NetworkPacket)bf.Deserialize(ms);
                        }
                        // deliver network packet to listeners
                        if(packet!=null) {
                            this.onNetworkPacketReceived?.Invoke(packet);
                        }
                        // update network statistics
                        NetworkStatistics.getInstance().TotalBytesRtpIn += data.Length;
                    }
                }
            } catch(SocketException ex) {
                onNetworkClientDisconnected?.Invoke(agent.SystemId);
            } catch(ObjectDisposedException ex) {
                onNetworkClientDisconnected?.Invoke(agent.SystemId);
            } catch(ThreadAbortException ex) {
                // allows your thread to terminate gracefully
                if(ex!=null) Thread.ResetAbort();
            }
        }
