    [WebMethod]
    public static bool NeedToUpdate(int lastRowCount)
    {
        int currentRowCount = getData().Rows.Count;
    
        // if the number of rows has changed, time to reload the page
        return (currentRowCount != lastRowCount);
    }
