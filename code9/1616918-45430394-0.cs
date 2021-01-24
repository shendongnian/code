                string requestParams = 'info={ "EmployeeID": [ "1234567", "7654321" ], "Salary": true, "BonusPercentage": 10}';
                webRequest = (HttpWebRequest)WebRequest.Create("http://example.com/xyz/php/api/createjob.php");
                webRequest.Method = "POST";
                webRequest.ContentType = "application/json";
                byte[] byteArray = Encoding.UTF8.GetBytes(requestParams);
                webRequest.ContentLength = byteArray.Length;
                using (Stream requestStream = webRequest.GetRequestStream())
                {
                    requestStream.Write(byteArray, 0, byteArray.Length);
                }
                // Get the response.
                using (WebResponse response = webRequest.GetResponse())
                {
                    using (Stream responseStream = response.GetResponseStream())
                    {
                        StreamReader rdr = new StreamReader(responseStream, Encoding.UTF8);
                        string Json = rdr.ReadToEnd();
                    }
                }
