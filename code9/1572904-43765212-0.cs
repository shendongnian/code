    byte[] byteArray = File.ReadAllBytes("excelFile.xlsx");
    using (MemoryStream ms = new MemoryStream())
    {
        ms.Write(byteArray, 0, (int)byteArray.Length);
        using (SpreadsheetDocument  doc = SpreadsheetDocument.Open(ms, true))
        {
           // Do work here
        }
        // Convert it to byte array 
        byte[] bytesInStream = ms.ToArray();
    }
