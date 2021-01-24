            try
            {
                string myparameters = "&Address=" + m.Address + "&Address2=" + m.Address2 + "&ContactNumber=" + m.ContactNumber + "&ContactPerson=" + m.ContactPerson + "&Designation=" + m.Designation + "&EmailId=" + m.EmailId + "&Pincode=" + m.Pincode;
                client.Headers["Content-type"] = "application/x-www-form-urlencoded";
                string htmlresult = client.UploadString(posturl, "POST", myparameters);
                Console.WriteLine(htmlresult);
            }
            catch (WebException e)
            {
                using (WebResponse response = e.Response)
                {
                    HttpWebResponse httpResponse = (HttpWebResponse)response;
                    Console.WriteLine("\nError code: {0}", httpResponse.StatusCode);
                    using (Stream data = response.GetResponseStream())
                    using (var readerr = new StreamReader(data))
                    {
                        string text = readerr.ReadToEnd();
                        Console.WriteLine(text);
                    }
                }
            }
