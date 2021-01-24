    private TcpClient _client; // Set this wherever you had your original Socket set up.
    private void receive() {
        try {
            using(var stream = _client.GetStream()) {
                BinaryFormatter bf = new BinaryFormatter();
                while(running) {
                        packet = (NetworkPacket)bf.Deserialize(stream);
                       
                        // deliver network packet to listeners
                        if(packet!=null) {
                            this.onNetworkPacketReceived?.Invoke(packet);
                        }
                        // update network statistics (not sure the best way to update this)
                        //NetworkStatistics.getInstance().TotalBytesRtpIn += data.Length;
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
