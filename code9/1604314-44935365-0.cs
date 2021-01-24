        static bool DownloadFileWithRange()
        {
            string link = "http://freelistenonline.com/"; //<- link to some big file
            string FilePath = @"C:\Test\1.zip";
            if (File.Exists(FilePath))
                File.Delete(FilePath);
            long totalBytesRead = 0;
            long MaxContentLength = 0;
            long RequestContentLength = 0;
            int i = 0;
            while (MaxContentLength == 0 || totalBytesRead < MaxContentLength)
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(link);
                if (totalBytesRead > 0) request.AddRange(totalBytesRead);
                WebResponse response = request.GetResponse();
                Console.WriteLine("=============== Request #{0} ==================", ++i);
                foreach (var header in response.Headers)
                {
                    if (header.ToSaveString().Contains("Content-Length") || header.ToSaveString().Contains("Content-Range"))
                        Console.WriteLine("{0}: {1}", header, response.Headers[header.ToString()]);
                }
                if (response.ContentLength > MaxContentLength)
                    MaxContentLength = response.ContentLength;             
                var ns = response.GetResponseStream();
                RequestContentLength = 0;
                try
                {
                    using (var responseStream = response.GetResponseStream())
                    {
                        using (FileStream localFileStream = new FileStream(FilePath, FileMode.Append))
                        {
                            var buffer = new byte[4096];
                            int bytesRead;
                            while ((bytesRead = responseStream.Read(buffer, 0, buffer.Length)) > 0)
                            {
                                totalBytesRead += bytesRead;
                                RequestContentLength += bytesRead;
                                localFileStream.Write(buffer, 0, bytesRead);
                            }
                            Console.WriteLine("Got bytes: {0}", RequestContentLength);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Got bytes: {0}", RequestContentLength);
                }
            }
            if (MaxContentLength == totalBytesRead)
                return true;
            return false;
        }
