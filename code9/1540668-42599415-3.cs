     static void Main(string[] args)
        {
            var cts = new CancellationTokenSource();
            var _lock = new Object();
            var po = new ParallelOptions();
            po.CancellationToken = cts.Token;
            po.MaxDegreeOfParallelism = System.Environment.ProcessorCount;
            var listOfUrls = new List<string>() { "url1", "url2" };
            var responsResult = "";
            try
            {
                Parallel.ForEach(listOfUrls, po, (url) =>
                {
                    po.CancellationToken.ThrowIfCancellationRequested();
                    HttpWebRequest wr = (HttpWebRequest)WebRequest.Create(url);
                    HttpWebResponse response = (HttpWebResponse)wr.GetResponse();
                    string responseString = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding(response.CharacterSet)).ReadToEnd();
                    lock (_lock)
                    {
                        if (responseString.Length > 6)
                        {
                           responsResult = responseString;
                            cts.Cancel();
                        }                        
                    }           
                });
            }
            catch (OperationCanceledException e)
            {
                //cancellation was requested
            }
            finally
            {
                cts.Dispose();
            }
        }
