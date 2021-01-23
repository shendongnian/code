    bool Scan(string filePath){
        Scanner.Scan(filePath);
        var result = Scanner.CheckStatus();
        while(result != ResultType.Positive)
        {
            System.Threading.Thread.Sleep(5000); //time in ms
            result = Scanner.CheckStatus();
        }
        return result
    }
    
