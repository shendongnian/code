        public static void FileDownload(string strDownUrl, string strSaveFile)
        {
            MessageBox.Show(strDownUrl);
            System.Net.HttpWebRequest request = null;
            System.Net.HttpWebResponse response = null;
            request = (System.Net.HttpWebRequest)System.Net.HttpWebRequest.Create(strDownUrl);
            request.Timeout = 30000;
            try
            {
                response = (System.Net.HttpWebResponse)request.GetResponse();
                Debug.WriteLine(string.Format("Content length is {0}", response.ContentLength));
                Debug.WriteLine(string.Format("Content type is {0}", response.ContentType));
                using (var file = File.OpenWrite(strSaveFile))
                using (Stream stream = response.GetResponseStream())
                {
                    if (stream == null)
                    {
                        Debug.WriteLine("Response is null, no file found on server");
                    }
                    else
                        stream.CopyTo(file);
                }
            }
            catch(Exception e)
            {
                Debug.WriteLine("Error during copying:"+e);
            }
        }
