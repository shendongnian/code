    //In this method you are returning a List
    public List<Result> GetAllKschl(string fileNameResult, string fileNameData)
    {
        List<Result> listResult = new List<Result>();
        docResult.Load(fileNameResult);
        docData.Load(fileNameData);
    
        var resultList = docResult.SelectNodes("//root/CalculationLogCompact/CalculationLogRowCompact");
    
        foreach (XmlNode nextText in resultList)
        {
            XmlNode KSCHL = nextText.SelectSingleNode("KSCHL");
            string nextKschl = KSCHL.InnerText;
    
            // ... and so on...
    
            if (pieces > 0 && totalPrice > 0)
            {
                listResult.Add(new Result(nextKschl, nextKSCHLData, nextEinzelpreis, pieces, totalPrice));
            }
        }
        return listResult;
    }
    //On the second method you returning a decimal and expecting a string    
    public decimal GetTotalAmount(string amount, string totalAmount)
    {
        string total = GetAllKschl(amount, totalAmount); // ??
    
        return total;
    }   
