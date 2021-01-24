    namespace Test //If you copy this, remember to change the namespace to match your application
    {
        class Shared
        {
            public static TcpClient client = new TcpClient(“server”, 6667);
            //OR do this and use the Connect method to connect later (see below)
            public static TcpClient client = new TcpClient();
        }
    }
