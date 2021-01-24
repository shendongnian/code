    class Program
    {
        static void Main(string[] args)
        {
            using (ClientConnectionServiceProxy proxy = new ClientConnectionServiceProxy())
            {
                bool isCallSuccessful = proxy.Connect(string.Empty);
            }
        }
    }
