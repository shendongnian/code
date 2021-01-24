            public static TcpClient OpenSession(string ServerIp, int ServerPort)
            {
                cServerControl Result = new cServerControl(ServerIp, ServerPort);
                Result.Connect();
                // [SNIP]
                return Result.TcpClient;
            }
