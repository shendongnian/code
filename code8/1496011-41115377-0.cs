    public MemoryStream ExportToCsv(string jsonData, HttpResponseBase response, string fileName)
    {
      using (MemoryStream stream = new MemoryStream())
      {
        StreamWriter writer = new StreamWriter(stream);
        try
        {
            String s = JsonToCsv(jsonData, ",");
            //fix - called Flush() method before writing to stream 
            writer.Flush();
            stream.Position = 0;
            writer.Write(s);
        }
        catch (Exception ex)
        {
            throw;
        }
        finally
        {
            writer.Close();
            response.Clear();
            response.Buffer = true;
            response.ContentType = "application/csv";
            response.AddHeader("Content-Disposition", "attachment; filename=" + fileName + "");
            response.BinaryWrite(stream.ToArray());
        }
        return stream;
    }
