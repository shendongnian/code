    private readonly Dictionary<String, String> _mimeTypes =
        new Dictionary<String, String> {{".mp3", "audio/mpeg"}, {".wav", "audio/vnd.wav"}}; // all audio mime types i am interessted in which do not follow the "audio/fileextension" format
    			
    private void DownloadFile(String path)
    {
        FileInfo file = new FileInfo(path);
    
        Int64 fileLength = file.Length;
        Int64 rangeTo = fileLength;
        String rangeHeader = Request.Headers["range"];
        String[] parts;
    
        if (rangeHeader != null)
        {
            rangeHeader = rangeHeader.Replace(" ", "").ToLower().Trim().Replace("bytes=", ""); // comes with the format of "bytes=0-100"
            parts = rangeHeader.Split('-').Where(x => !String.IsNullOrWhiteSpace(x)).ToArray(); splits into "0" and "100"
        }
        else
        {
            parts = new[] {"0"}; // simulate 0- range, full file will be returned
        }
    
    	// trying to parse range
        Int64 rangeFrom = 0;
        switch (parts.Length)
        {
            case 2:
            {
                // full range passed (e.g. "100-200")
                if (!Int64.TryParse(parts[1], out rangeTo))
                {
                    // cannot parse input to int -> invalid
                    SendResponseRangeNotSatisfiable();
                    return;
                }
    
                goto case 1;
            }
            case 1:
                // only start provided (e.g. "0-")
                if (!Int64.TryParse(parts[0], out rangeFrom))
                {
                    // cannot parse input to int -> invalid
                    SendResponseRangeNotSatisfiable();
                    return;
                }
    
                goto case 0;
            case 0:
            {
                // no range provided, take default value for full file (e.g. "0-..")
    			Response.Clear();
    			Response.ClearHeaders();
    			Response.ClearContent();
    			Response.StatusCode = rangeFrom == 0 && rangeTo == fileLength
    				? (Int32) HttpStatusCode.OK
    				: (Int32) HttpStatusCode.PartialContent;
    			Response.AddHeader("Accept-Ranges", "bytes");
    			Response.AddHeader("Content-Disposition", $"inline; filename=\"{file.FullName}\"");
    			Response.AddHeader("Content-Length", fileLength.ToString());
    			Response.AddHeader("Content-Range", $"bytes {rangeFrom}-{rangeTo - 1}/{fileLength}");
    			Response.ContentType = _mimeTypes.ContainsKey(file.Extension)
    				? _mimeTypes[file.Extension]
    				: $"audio/{file.Extension.Substring(1)}";
    			String contentDuration = TheLengthOfYourMusicFileInSeconds;
    			Response.AddHeader("X-Content-Duration", contentDuration);
    			Response.AddHeader("Content-Duration", contentDuration);
    			Response.TransmitFile(file.FullName, rangeFrom, rangeTo - rangeFrom);
    			Response.Flush();
    			Response.End();
                break;
            }
            default:
                SendResponseRangeNotSatisfiable();
                return;
        }
    }
    
    private void SendResponseRangeNotSatisfiable()
    {
        Response.Clear();
        Response.ClearHeaders();
        Response.ClearContent();
        Response.StatusCode = (Int32) HttpStatusCode.RequestedRangeNotSatisfiable;
        Response.Flush();
        Response.End();
    }
