    using (WebClient myWebClient = new WebClient())
                                {
                                    myWebClient.Headers.Add("User-Agent: Other");
                                    myWebClient.Headers.Add(HttpRequestHeader.Cookie, "mycookies copies from EditThisCookie");
                                    myWebClient.DownloadFile(new System.Uri("https://mywebsite.com//somefile"), "D:\\temp\\somefile");
                                }
