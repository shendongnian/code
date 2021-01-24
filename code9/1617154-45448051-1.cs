    public void CopyImport2CT(string myTable)
    {
        //Copy data Importtable to Landentabel
        try
        {
            using (OleDbConnection mycopy2CTConn = new OleDbConnection(strProviderConn))
            {
                string copystring = "INSERT INTO Landentabel (LandenID, Landnummer, Landnaam, Piektarief, Daltarief, Weekendtarief) SELECT (SELECT COUNT(*) FROM " + myTable + " WHERE e.CountryCode >= CountryCode) AS Id, e.CountryCode, e.Country, e.HighFee, e.LowFee, e.Weekendfee from " + myTable + " e ORDER BY e.CountryCode";
                using (OleDbCommand myProviderCommand = new OleDbCommand(copystring, mycopy2CTConn))
                {
                    mycopy2CTConn.Open();
                    myProviderCommand.ExecuteNonQuery();
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: Failed to create a copy data. \n{0}", ex.Message);
            throw ex;
        }
    }
