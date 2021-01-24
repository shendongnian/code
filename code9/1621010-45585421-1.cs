    // for brevity, removed all unchanged parts...
    public class CommManager
    {
        private static readonly List<IChannel> channels = new List<IChannel>();
    private void ChannelCollectionChanged(object sender, 
        NotifyCollectionChangedEventArgs args)
        {
            switch (args.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    foreach (ChannelConfig newItem in args.NewItems)
                        CommManager.channels.Add(CreateChannel(newItem));
                    break;
                case Notif.. /// etc. etc.
            }
        }
        public static IChannel GetChannel(CommChannel channelNr)
        {
            return CommManager.channels[(int)channelNr];
        }
    }
