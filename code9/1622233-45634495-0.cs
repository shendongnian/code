    private List<Currency> CurrencyList = new List<Currency>();
    public CurrencyForm()
    {
       // Your logic here 
       while (!text.Contains("count"))
       {
            CurrencyList.Add(new Currency());
       }
    }
