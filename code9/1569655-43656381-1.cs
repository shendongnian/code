    public class MyHub : Hub
    {
        public static void SendMeData(string dataString)
        {
           Clients.All.SendMeData(dataString);
        }
    }
