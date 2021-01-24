    private void receive() {
        try {
            while(running) {
                int offset = 0;
                byte[] header = new byte[4];
                // receive header bytes from tcp stream
                while (offset < header.Length) {
                    offset += clientSocket.Receive(header, offset, header.Length - offset, SocketFlags.None);
                }
                    int bytesToRead = BitConverter.ToInt32(header, 0);
                    // receive body bytes from tcp stream
                    offset = 0;
                    byte[] data = new byte[bytesToRead];
                    while(offset < data.Length) {
                        offset += clientSocket.Receive(data, offset, data.Length - offset, SocketFlags.None);
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
