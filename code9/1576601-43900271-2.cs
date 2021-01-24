    public void ProcessPayment(IClient client, decimal amount)
    {
        if (!client.TryCharge(amount))
           throw new BlahBlahException();
    }
