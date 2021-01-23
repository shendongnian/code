        XmlDocument GetRssElement (string url)
        {
            try
            {
                var httpClient = new HttpClient();
                #Region httpClientHeaders
                httpClient.DefaultRequestHeaders.AcceptLanguage.Clear ();
                httpClient.DefaultRequestHeaders.AcceptLanguage.Add (new StringWithQualityHeaderValue ("en-US"));
                httpClient.DefaultRequestHeaders.AcceptLanguage.Add (new StringWithQualityHeaderValue ("en"));
                httpClient.DefaultRequestHeaders.AcceptLanguage.Add (new StringWithQualityHeaderValue ("fa"));
                httpClient.DefaultRequestHeaders.TryAddWithoutValidation ("User-Agent", "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/54.0.2840.71 Safari/537.36");
                httpClient.DefaultRequestHeaders.TryAddWithoutValidation ("Connection", "keep-alive");
                httpClient.Timeout = TimeSpan.FromMinutes (1000);
                var xmlDoc = new XmlDocument();
                #EndRegion
                try
                {
                    var stream = httpClient.GetAsync(rssLinkRecord.Url.Replace("feed://", ""));
                    xmlDoc.LoadXml (stream.Result.Content.ReadAsStringAsync ().Result);
                }
                catch (XmlException) //if xml need encoding.
                {
                    var wc = new WebClient();
                    var encoding = Encoding.GetEncoding("utf-8");
                    var data = wc.DownloadData(rssLinkRecord.Url.Replace("feed://", ""));
                    var gzip = new GZipStream(new MemoryStream(data), CompressionMode.Decompress);
                    var decompressed = new MemoryStream();
                    gzip.CopyTo (decompressed);
                    var str = encoding.GetString(decompressed.GetBuffer(), 0, (int) decompressed.Length);
                    xmlDoc = new XmlDocument ();
                    xmlDoc.LoadXml (str);
                }
                return xmlDoc;
            }
            catch (TaskCanceledException ex){}
            catch (AggregateException aex){}
            catch (XmlException xexi){}
            catch (WebException wex){}
            catch (Exception ex){}
        }
