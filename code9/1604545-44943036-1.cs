    using (Client client = new Client("localhost",80, new System.Threading.CancellationToken()))
    {
        await client.WriteLine("abcd");
        string response = await client.ReadAsync();
        Console.WriteLine(response);
    }
