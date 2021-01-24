    private List<List<String>> _symbolParams = new List<List<String>> { };
    //Backtest Constructor
    public Backtest(List<List<string>> symbolParams,
                    Dictionary<string, List<string>> symbolDates,
                    BackgroundWorker bw)
    {
        _symbolParams = symbolParams;
        _symbolDates = symbolDates;
        _bw = bw;
    }
