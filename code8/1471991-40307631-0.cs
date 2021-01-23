    public static async Task DoAsync()
    {
        var strApiAddress = "http://localhost";
        HttpClient client = new HttpClient();
        var str = await client.GetStringAsync(strApiAddress);
    }
    public static void Do()
    {
        var strApiAddress = "http://localhost";
        HttpClient client = new HttpClient();
        var str = client.GetStringAsync(strApiAddress).Result;
    }
