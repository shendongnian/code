     private class YourWebClient : WebClient
            {
                protected override WebRequest GetWebRequest(Uri uri)
                {
                    WebRequest wr = base.GetWebRequest(uri);
                    wr.Timeout = 7 * 1000;
                    return wr;
                }
            }
