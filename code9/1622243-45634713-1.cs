    class Client {
        static int count = 0;
        public string Name { get; set; }
        public Client() {
            Name = string.Format("client{0}", count++);
        }
    }
