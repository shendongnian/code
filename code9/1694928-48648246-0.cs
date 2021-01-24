        public class InterAppDomainForSignalR : MarshalByRefObject
        {
            public void Publish(PublishParameter param) {
                var clients = GlobalHost.ConnectionManager.GetHubContext<TradeHub>().Clients;
                dynamic chan;
                if (param.group != null && param.group.Length > 0)
                {
                    chan = clients.Group(param.group, param.ids);
                }
                else
                {
                    if(param.ids == null || param.ids.length = 0) {
                        return; //not supposed to happen
                    }
                    chan = clients.Client(param.ids[0]);
                }
                chan.OnEvent(param.channelEvent.ChannelName, param.channelEvent);
            }
        }
        
        [Serializable]
        public class PublishParameter
        {
            public string group { get; set; }
            public string[] ids { get; set; }
            public ChannelEvent channelEvent { get; set; }
        }
