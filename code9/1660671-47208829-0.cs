    string GetSumOrErrorMessage(int idToMatch, IEnumerable<DataRow> dataRow)
    {
    	try
    	{
    		var sum = dataRow.Where(x => (int)x[2] == idToMatch).Sum(x => double.Parse(x[3].ToString()));
    		return sum.ToString();
    	}
    	catch (Exception)
    	{
    		return "Error happened here"; // or something more specific
    	}
    }
