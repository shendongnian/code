                int Offset = 0 ;
                WebRequest req = WebRequest.Create("https://api.telegram.org/bot" + "Token" + "/getUpdates?offset=" + Offset;);
                req.UseDefaultCredentials = true;
                WebResponse resp = req.GetResponse();
                Stream stream = resp.GetResponseStream();
                StreamReader sr = new StreamReader(stream);
                string s = sr.ReadToEnd();
                sr.Close();
                var jobject = Newtonsoft.Json.Linq.JObject.Parse(s);
                mydata gg = JsonConvert.DeserializeObject<mydata>(jobject.ToString());
                List<result> results = new List<result>();
                foreach (result rs in gg.result)
                {
                    results.Add(rs);
                    SendMessage(rs.message.chat.id.ToString(), "hello" + " " + "Dear" + rs.message.chat.first_name);
                }
