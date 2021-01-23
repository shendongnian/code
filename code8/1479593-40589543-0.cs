            void PostComplaint()
        {
            HttpWebRequest req = null;
            HttpWebResponse res = null;
            string url = "http://localhost:28522/Complaints.svc/insertcomplaint";
            ComplaintData iData = new ComplaintData();
            iData.ComplaintID = txtComplaintID.Text;
            iData.EntryBy = txtEntryBy.Text;
            req = (HttpWebRequest)WebRequest.Create(url);
            req.Method = "POST";
            req.ContentType = "application/json";
            req.Headers.Add("SOAPAction", url);
            using (var streamWriter = new StreamWriter(req.GetRequestStream()))
            {
                streamWriter.Write(Newtonsoft.Json.JsonConvert.SerializeObject(iData));
            }
            res = (HttpWebResponse)req.GetResponse();
            using (var streamReader = new StreamReader(res.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                TextBox1.Text = result;
            }
        }
