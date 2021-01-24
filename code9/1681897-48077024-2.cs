    namespace Test
    {
        class Shared
        {
            public static TcpClient client = new TcpClient(“server”, 6667);
            //OR do this and use the Connect method to connect later
            public static TcpClient client = new TcpClient();
        }
    }
