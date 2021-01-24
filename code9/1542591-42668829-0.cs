    string SIDsubresult = subresult;
        SIDsubresult = SIDsubresult.Replace(".", "");
        string SIDresult = result;
        SIDresult = SIDresult.Replace(".", "");
        long iSIDs = Convert.ToInt64(SIDsubresult);
        long iSIDr = Convert.ToInt64(SIDresult);
        Console.Write(iSIDr & iSIDs);
