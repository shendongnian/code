    public class MultipartParser
    {
        public IDictionary<string, string> Parameters = new Dictionary<string, string>();
        public MultipartParser(Stream stream)
        {
            this.Parse(stream, Encoding.UTF8);
        }
        public MultipartParser(Stream stream, Encoding encoding)
        {
            this.Parse(stream, encoding);
        }
        public string getcontent(Stream stream, Encoding encoding)
        {
            // Read the stream into a byte array
            byte[] data = ToByteArray(stream);
            // Copy to a string for header parsing
            string content = encoding.GetString(data);
            string delimiter = content.Substring(0, content.IndexOf("\r\n"));
            string[] sections = content.Split(new string[] { delimiter }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string s in sections)
            {
                Match nameMatch = new Regex(@"(?<=name\=\"")(.*?)(?=\"")").Match(s);
                string name = nameMatch.Value.Trim().ToLower();
                if (!string.IsNullOrWhiteSpace(name))
                {
                    int startIndex = nameMatch.Index + nameMatch.Length + "\r\n\r\n".Length;
                }
            }
            string strRet = ""; //Parameters["name"];
            return strRet;
        }
        private void Parse(Stream stream, Encoding encoding)
        {
            this.Success = false;            
            byte[] data = ToByteArray(stream);            
            string content = encoding.GetString(data);
            string s_no = content.Substring(content.IndexOf("s_no"), 100);                       
            string[] lines = s_no.Split(new[] { "\r\n", "\r\n\r\n" }, StringSplitOptions.None);
            this.S_NO = lines[3];            
            
            string count = content.Substring(content.IndexOf("Count"), 100);            
            string[] linescount = count.Split(new[] { "\r\n", "\r\n\r\n" }, StringSplitOptions.None);
            this.Count = linescount[3];   
                        
            int delimiterEndIndex = content.IndexOf("\r\n");
            if (delimiterEndIndex > -1)
            {
                string delimiter = content.Substring(0, content.IndexOf("\r\n"));
                // Look for Content-Type
                Regex re = new Regex(@"(?<=Content\-Type:)(.*?)");
                Match contentTypeMatch = re.Match(content);
                // Look for filename
                re = new Regex(@"(?<=filename\=\"")(.*?)(?=\"")");
                Match filenameMatch = re.Match(content);
                re = new Regex(@"(?<=Content\-Length:)(.*)");
                Match contentLenMatch = re.Match(content);
                if (contentLenMatch.Success)
                {
                    contentLenMatch = contentLenMatch.NextMatch();
                }
                if (contentLenMatch.Success)
                {
                    contentLenMatch = contentLenMatch.NextMatch();
                }
                //re = new Regex(@"(?<=name\=\"")(.*?)(?=\"")");
                //Match nameMatch = re.Match(content);
                // Did we find the required values?
                if (contentTypeMatch.Success && filenameMatch.Success)
                {
                    // Set properties
                    this.ContentType = contentTypeMatch.Value.Trim();
                    this.Filename = filenameMatch.Value.Trim();
                    // Get the start & end indexes of the file contents
                    int startIndex = contentLenMatch.Index + contentLenMatch.Length + "\r\n".Length + 1;
                    byte[] delimiterBytes = encoding.GetBytes("\r\n" + delimiter);
                    int endIndex = IndexOf(data, delimiterBytes, startIndex);
                    int contentLength = endIndex - startIndex;
                    // Extract the file contents from the byte array
                    byte[] fileData = new byte[contentLength];
                    Buffer.BlockCopy(data, startIndex, fileData, 0, contentLength);
                    this.FileContents = fileData;
                    this.Success = true;
                }
            }
        }
        private int IndexOf(byte[] searchWithin, byte[] serachFor, int startIndex)
        {
            int index = 0;
            int startPos = Array.IndexOf(searchWithin, serachFor[0], startIndex);
            if (startPos != -1)
            {
                while ((startPos + index) < searchWithin.Length)
                {
                    if (searchWithin[startPos + index] == serachFor[index])
                    {
                        index++;
                        if (index == serachFor.Length)
                        {
                            return startPos;
                        }
                    }
                    else
                    {
                        startPos = Array.IndexOf<byte>(searchWithin, serachFor[0], startPos + index);
                        if (startPos == -1)
                        {
                            return -1;
                        }
                        index = 0;
                    }
                }
            }
            return -1;
        }
        private byte[] ToByteArray(Stream stream)
        {
            byte[] buffer = new byte[32768];
            using (MemoryStream ms = new MemoryStream())
            {
                while (true)
                {
                    int read = stream.Read(buffer, 0, buffer.Length);
                    if (read <= 0)
                        return ms.ToArray();
                    ms.Write(buffer, 0, read);
                }
            }
        }
        public bool Success
        {
            get;
            private set;
        }
        public string ContentType
        {
            get;
            private set;
        }
        public string Filename
        {
            get;
            private set;
        }
        public byte[] FileContents
        {
            get;
            private set;
        }
        public string Imgname
        {
            get;
            private set;
        }
        public string S_NO
        {
            get;
            private set;
        }
        public string Count
        {
            get;
            private set;
        }
    }
    // End of Wcf rest Service Code
