                string lnk = @"https://scontent-sit4-1.xx.fbcdn.net/v/t1.0-9/14333603_1289676231065862_2460190844802989442_n.jpg?oh=f6ccebc305e599e6dcc0bb7c994d8ac4&oe=586F4DD8";
                WebRequest request = HttpWebRequest.Create(lnk);
                ((HttpWebRequest)request).AllowAutoRedirect = true;
                ((HttpWebRequest)request).UserAgent = @"Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)";
                int dataLength;
                int bytesRead;
                int wroteSoFar = 0;
                var response = request.GetResponse();
                Stream responseStream = response.GetResponseStream();
    
    
                byte[] buffer = new byte[1024];
                using (FileStream oFile = new FileStream(Path.Combine(Environment.CurrentDirectory, @"img.jpg"), FileMode.Append, FileAccess.Write))
                {
                    dataLength = (int)response.ContentLength;
                    do
                    {
                        bytesRead = responseStream.Read(buffer, 0, buffer.Length);
                        oFile.Write(buffer, 0, bytesRead);
                        wroteSoFar += bytesRead;
                        //Console.WriteLine($"{(wroteSoFar / 1000).ToString("N0")} KB / {(dataLength / 1000).ToString("N0")} KB");
                    }
                    while (bytesRead != 0);
                }
