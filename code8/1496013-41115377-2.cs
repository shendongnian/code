    public MemoryStream ExportToCsv(string jsonData, HttpResponseBase response, string fileName)
    {
           using (MemoryStream stream = new MemoryStream())
            {
                StreamWriter writer = new StreamWriter(stream);
                try
                {
                    response.Clear();
                    response.Buffer = true;
                    response.ContentType = "application/csv";
                    response.AddHeader("Content-Disposition", "attachment; filename=" + fileName + "");
                    String s = JsonToCsv(jsonData, ",");
                    writer.Write(s);
                    writer.Flush();
                   
                    stream.Position = 0;
                    response.BinaryWrite(stream.ToArray());
                }
                catch (Exception ex)
                {
                    
                    throw;
                }
                finally
                {
                    writer.Close();
                }
        return stream;
    }
