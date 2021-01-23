    public static class ServiceCom
    {
        public static void SendMessage(string messageBody)
        {
            var messageBus = RabbitHutch.CreateBus("host=localhost");
            messageBus.Send("pipeline", new Message { Body = messageBody });
        }
    }
