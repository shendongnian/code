    Task.Factory.StartNew(() => ConnectionHandler(), TaskCreationsOption.LongRunning);
    
    private void ConnectionHandler() {
            var connectionState = ConnectionState.AwaitPortSelected;
            while (!SerialPortCts.IsCancellationRequested) {
                switch (connectionState) {
                    case ConnectionState.AwaitPortSelected:
                        break;
                    case ConnectionState.IsPortValid:
                        break;
                    case ConnectionState.OpenPort:
                        break;
                    case ConnectionState.AwaitLinkStateChange:
                        break;
                    case ConnectionState.ClosePort:
                        break;
    
                    Thread.Sleep(1);
                }
            }
        }
