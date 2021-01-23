      var httpResponse = (System.Net.HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new System.IO.StreamReader(httpResponse.GetResponseStream()))
                {
                    var responseText = streamReader.ReadToEnd();
                    Console.Write(responseText);
                    var data = (JObject)JsonConvert.DeserializeObject(responseText);
                    var name = data["number"];
                    Console.WriteLine("Version Number" + name);
                }
