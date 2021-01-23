    public void Handler(string data)
    {
        //Console.WriteLine(data);
        _clients[0].Client.Send(Encoding.UTF8.GetBytes(data));
    }
    ...
    _comPipe.Received += Handler;
