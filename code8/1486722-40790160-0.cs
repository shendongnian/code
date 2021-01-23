    public class timehub : Hub
    {
        public void Send()
        {
            while(true)
            {
                var current = DateTime.Now.ToString("HH:mm:ss:tt");
                Clients.All.broadcastMessage(current);
                System.Threading.Thread.Sleep(5000);
            }
        }
    }
