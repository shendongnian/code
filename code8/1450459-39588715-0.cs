    try
    {
        string dateString = rowData["Date"].ToString();    
    }
    catch (System.Exception ex)
    {
        throw new System.Exception("Couldn't get Data from Row! Maybe wrong DataType?")
    }    
    DateTime dateValue;
    if (!DateTime.TryParse(dateString, out dateValue))
    {
        // handle parse failure
        throw new System.Exception("Couldn't parse this String: " + dateString)
    }
