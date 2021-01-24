    public static string register(string username, string password, string email, string act_link)
        {
            string s = string.Empty;
            try
            {
                string site = "http://yoursite.com/";
                HttpWebRequest wr = (HttpWebRequest)WebRequest.Create(site + "register.php?u=" + username + "&p=" + sha1(password) + "&e=" + email + "&tmp=" + sha1(act_link));
                StreamReader sr = new StreamReader(wr.GetResponse().GetResponseStream());
                s = sr.ReadToEnd();
            }
            catch (Exception ex) { }
            return s;
        }
