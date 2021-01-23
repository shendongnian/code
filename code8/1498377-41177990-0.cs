    StringBuilder strBuilder = new StringBuilder();
    foreach (var item in vbCodes)
    {
        strBuilder.Append(item.Formula).Append(" || ");
    }
    string strFuntionResult = strBuilder.ToString(); // extra || will be at the end
    // To remove that you have to Trim those characters 
    // or take substring till that
    strFuntionResult = strFuntionResult.Substring(0, strFuntionResult.LastIndexOf('|')); 
