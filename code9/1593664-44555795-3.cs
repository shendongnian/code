    private TcpClient _client; // Set this wherever you had your original Socket set up.
    private void receive() {
        try {
            using(var stream = _client.GetStream()) {
                BinaryFormatter bf = new BinaryFormatter();
                while(running) {
                        
                        
    #region This part is not needed if you are only going to deserialize the stream and not update TotalBytesRtpIn, make sure the server stops sending the header too!
                        int offset = 0;
                        byte[] header = new byte[4];
                        // receive header bytes from tcp stream
                        while (offset < header.Length) {
                            offset += stream.Read(header, offset, header.Length - offset);
                        }
                        int bytesToRead = BitConverter.ToInt32(header, 0);
    #endregion
                        packet = (NetworkPacket)bf.Deserialize(stream);
                       
                        // deliver network packet to listeners
                        if(packet!=null) {
                            this.onNetworkPacketReceived?.Invoke(packet);
                        }
                        // update network statistics
                        NetworkStatistics.getInstance().TotalBytesRtpIn += bytesToRead;
                    }
                }
            }
        //These may need to get changed.
        } catch(SocketException ex) {
            onNetworkClientDisconnected?.Invoke(agent.SystemId);
        } catch(ObjectDisposedException ex) {
            onNetworkClientDisconnected?.Invoke(agent.SystemId);
        } catch(ThreadAbortException ex) {
            // allows your thread to terminate gracefully
            if(ex!=null) Thread.ResetAbort();
        }
    }
