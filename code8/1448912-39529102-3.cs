        static void Main(string[] args) 
        {
           var connStr = "Server=localhost;User=root;Database=test;Password=root;Min Pool Size=3;Max Pool Size=5;Pooling=True";
           MonitorClass monitor = new MonitorClass(connStr);
           monitor.Run();
           //...
        }
