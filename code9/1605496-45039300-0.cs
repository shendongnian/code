    public IHttpActionResult GetDownloadLetter()
    {
        DownloadDocument docInfo = blogicObj.DownloadLetter();
        var result = new HttpResponseMessage(HttpStatusCode.OK)
        {
            Content = new ByteArrayContent(docInfo.Document.ToArray())
        };
        result.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment")
        {
            FileName = docInfo.DocumentName + ".zip"
        };
    
        result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/zip");
        var response = ResponseMessage(result);
        return response;
    }
    
    
    public class DownloadDocument
    {
        public MemoryStream Document { get; set; }
        public string DocumentType { get; set; }
        public string DocumentName { get; set; }
    }
    
    public DownloadDocument DownloadDocument()
    {
        DownloadDocument letter = null;
        try
        {
            letter = GetDummyDownload();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return letter;
    }
    
    public MemoryStream GetMemoryStream(SqlDataReader reader, int columnIndex)
    {
          byte[] buffer = (byte[])reader.GetValue(columnIndex);
                MemoryStream stream = new MemoryStream(buffer);
                return stream;
    }
    
    public DownloadDocument GetDummyDownload()
    {
        DownloadDocument letter = null;
        string strQuery = "select * from [dbo].[documents] where id=1";
    
        using (SqlConnection connection = new SqlConnection(connStr))
        {
            SqlCommand command = new SqlCommand(connStr);
            command.CommandType = CommandType.Text;
            command.CommandText = strQuery;
            command.Connection = connection;
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            // Call Read before accessing data.
            while (reader.Read())
            {
                letter = new DownloadDocument();
                letter.Document = GetMemoryStream(reader, 4); //4 is for document column
                letter.DocumentType = Convert.ToString(reader["DocumentType"]);
                letter.DocumentName = Convert.ToString(reader["Name"]);
            }
            // Call Close when done reading.
            reader.Close();
        }
        return letter;
    }
