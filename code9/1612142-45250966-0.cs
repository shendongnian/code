    public class HeartBeat : IHeartBeat
    {
        public string GetData()
        {
            OperationContext context = OperationContext.Current;
            MessageProperties prop = context.IncomingMessageProperties;
            RemoteEndpointMessageProperty endpoint =
                prop[RemoteEndpointMessageProperty.Name] as RemoteEndpointMessageProperty;
            string ip = endpoint.Address;
            EndpointAddress test = OperationContext.Current.Channel.RemoteAddress;
            IPHostEntry ipHostEntry = Dns.GetHostEntry(System.ServiceModel.OperationContext.Current.Channel.RemoteAddress.Uri.Host);
            foreach (IPAddress ip2 in ipHostEntry.AddressList)
            {
                if (ip2.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    //System.Diagnostics.Debug.WriteLine("LocalIPadress: " + ip);
                    return ip2.ToString();
                }
            }
            return "IP address is: " +  System.ServiceModel.OperationContext.Current.Channel.RemoteAddress.Uri.Host;
        }
    }
