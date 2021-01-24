            try
            {
                var wc = new WebClient { Encoding = encoding };
                var readStream = wc.OpenRead(url);
                using (var sr = new StreamReader(readStream, encoding))
                {
                    var result = sr.ReadToEnd();
                    return result;
                }
            }
            catch (Exception e)
            {
                //throw e;
                return e.Message;
            }
        }
