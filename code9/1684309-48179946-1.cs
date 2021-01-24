    public void Receive(List<RealDataModel> models)
    {
        Broast(o => o.Receive(models));
    }
    public void SendResult(string msg)
    {
        Broast(o => o.SendResult(msg));
    }
