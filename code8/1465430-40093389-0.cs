     public class SenderEvent
        {
            public void DataSender(string data, string eventhubname)
            {
                var eventhubclient = EventHubClient.CreateFromConnectionString(ConstFile.eventHubConnectionString, eventhubname);       
                EventData data1 = new EventData(Encoding.UTF8.GetBytes(data));
                eventhubclient.Send(data1);
            }
