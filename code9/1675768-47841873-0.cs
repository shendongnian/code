    public string GetIPConnectingTo(string targetIP, int port = 80){
        try {
            using(var tc = new TcpClient(targetIP, port)){
               return tc.Client.LocalEndPoint.ToString().Split(':')[0];
            }
        }
        catch {
            return null;
        }
    }
