    [TestMethod]
    public void ReceiveMessages()
    {
        subClient.OnMessage(msg => {
            System.Diagnostics.Trace.TraceInformation($"{DateTime.Now}：{msg.GetBody<string>()}");
            msg.Complete();
        });
        Task.Delay(TimeSpan.FromMinutes(5)).Wait();
    }
