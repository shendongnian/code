            System.Diagnostics.Debug.WriteLine("Hbase_update");
            //check your port number to make sure you have the right one
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(@"http://localhost:8080/Images/" + key + "?data=");
            request.Method = "PUT";
            
            //NOTE:The name of the column I am pushing to is int the Column Family "Image" and column "Binary"
            string requestStr =  @"<?xml version=""1.0"" encoding=""UTF-8"" standalone=""yes""?><CellSet><Row key=""" + Convert.ToBase64String(Encoding.UTF8.GetBytes(key)) + @"""><Cell column=""" + Convert.ToBase64String(Encoding.UTF8.GetBytes("Image:Binary")) + @""">"+ imageBinary + @"</Cell></Row></CellSet>";
            var data = Encoding.ASCII.GetBytes(requestStr);
            
            request.Accept = "text/xml";
            request.ContentType = "text/xml; encoding='utf-8'";
            request.ContentLength = data.Length;
            Stream dataStream = request.GetRequestStream();
            dataStream.Write(data, 0, data.Length);
            dataStream.Close();
            try
                {
                var response = (HttpWebResponse)request.GetResponse();
                var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
                System.Diagnostics.Debug.WriteLine(responseString);
            }
            catch (System.Net.WebException e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
