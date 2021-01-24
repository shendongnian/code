        string getman(string url)
        {
            List<string> result = new List<string>();
            try
            {
                HttpWebRequest r = (HttpWebRequest)WebRequest.Create(url);
                r.UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64; rv:51.0) Gecko/20100101 Firefox/51.0";
                r.Method = "GET";
                HttpWebResponse res = (HttpWebResponse)r.GetResponse();
                StreamReader sr = new StreamReader(res.GetResponseStream());
                string oku = sr.ReadToEnd();
                Regex regex = new Regex(textBox1.Text + "(.*?)" + textBox2.Text);
                MatchCollection m = regex.Matches(oku);
                foreach (Match match in m)
                {
                    result.Add(match.Groups[1].ToString() + "\r\n");
                }
                res.Close();
                sr.Close();
            }
            catch {  }
            return String.Join(",", result.ToArray());
        }
