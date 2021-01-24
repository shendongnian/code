            public static string Send(Iso8583 msg, string IP, int Port)
        {
            var messagebits = msg.ToMsg();
            string result = "";
            try
            {
                TcpClient tcpclnt = new TcpClient();
                tcpclnt.Connect(IP, Port);
                Stream stream = tcpclnt.GetStream();
                ASCIIEncoding asen = new ASCIIEncoding();
                stream.Write(messagebits, 0, messagebits.Length);
                var lengthHeader = new byte[2];
                stream.Read(lengthHeader, 0, 2);
                var rspLength = lengthHeader[0] * 256 + lengthHeader[1];
                var rspData = new byte[rspLength];
                stream.Read(rspData, 0, rspLength);
                tcpclnt.Close();
                Iso8583 msgIso = new Iso8583();
                msgIso.Unpack(rspData, 0);
            }
            catch (Exception) { }
            return result;
        }
