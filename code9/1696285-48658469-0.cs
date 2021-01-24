    protected async Task<HttpResponseMessage> GetExcel()
    {
    	var stream = await MakeReport();
    	var byteArray = ToByteArray(stream);
    	var result = new HttpResponseMessage(HttpStatusCode.OK);
    	result.Content = new ByteArrayContent(byteArray);
    	result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
    	result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment"); //attachment will force download
    	result.Content.Headers.ContentDisposition.FileName = "Report.xlsx";
    	return result;
    }
    
    public static byte[] ToByteArray(Stream input)
    {
        using (MemoryStream ms = new MemoryStream())
        {
            input.CopyTo(ms);
            return ms.ToArray();
        }
    }
