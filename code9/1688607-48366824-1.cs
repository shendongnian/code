    public void Display(List<Crypto> cryptos)
    {
        foreach (Crypto crypto in cryptos)
        {
            foreach (Ticker ticker in crypto.Tickers)
            {
                Console.WriteLine(ticker);
            }
        }
    }
