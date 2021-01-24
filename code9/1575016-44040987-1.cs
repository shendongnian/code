    device.IsDataTerminalReadyEnabled = true;
            device.IsRequestToSendEnabled = true;
    
            var dataWriter = new DataWriter(device.OutputStream);
                        
            byte[] message = System.Text.Encoding.ASCII.GetBytes(command + "\r\n");
            dataWriter.WriteBytes(message);
    
            await dataWriter.StoreAsync();
    
            dataWriter.DetachStream();
            dataWriter = null;
