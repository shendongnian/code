    using(TextWriter writer = new StreamWriter(saveFilePath, false))
    {
        theTime = System.DateTime.Now.ToString("hh:mm:ss"); theDate = System.DateTime.Now.ToString("dd/MM/yyyy");
        string ZeroPart = theTime + "," + theDate + ",";
        string FirstPart = income;
        writer.WriteLine(ZeroPart + FirstPart);
        writer.Close();
    }
