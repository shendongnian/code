    static bool IsRdpAvailable(string host) {
        try {
            using (new TcpClient(host, 3389)) {
                return true;
            }
        }
        catch {
            return false;
        }
    } 
