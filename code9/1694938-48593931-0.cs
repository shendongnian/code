    public static string Btc;
    public static async Task SendRequestAsync()
    {
        var request = WebRequest.Create("https://api.coinbase.com/v2/prices/USD/spot?");
        using (var response = await request.GetResponseAsync())
            while (true)
            {
                using (var reader = new StreamReader(response.GetResponseStream()))
                {
                    var html = await reader.ReadLineAsync();
                    Btc = Regex.Match(html, @"""BTC"",""currency"":""USD"",""amount"":""([^ ""]*)""}").ToString();
                    await Task.Delay(300);
                }
            }
    }
