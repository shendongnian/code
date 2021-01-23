    private string GetServiceCode<T>(string cc, Action<T> action)
    {
        var code = AllCodes.Where(x => x.CountryCode == cc).FirstOrDefault();
        if (code != null)
        {
            return action(code);
        }
    }
    // Example:
    GetServiceCode("US",(code)=> Console.WriteLine(code.refprint) );
