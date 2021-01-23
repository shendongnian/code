            try
            {
                using(var client = new WebClient())
                {
                    var task = client.DownloadStringTaskAsync(Url);                    
                    if (task.Wait(300000))
                    {
                        var text = new StringReader(task.Result);
                        reader = new XmlTextReader(text);
                        return true;
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
