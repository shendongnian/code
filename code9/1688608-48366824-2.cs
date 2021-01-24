    public void Display(List<Crypto> cryptos)
    {
        foreach (Ticker ticker in cryptos.SelectMany(crypto => crypto.Tickers))
        {
            Console.WriteLine(ticker);
        }
    }
