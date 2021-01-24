        public static bool IsValidCaptcha()
        {
            var secret = "--------------Secret Key ---------------";
            var req =
                (HttpWebRequest)
                    WebRequest.Create("https://www.google.com/recaptcha/api/siteverify" + secret + "?secret=&response=" + HttpContext.Current.Request.Form["g-recaptcha-response"]);
            using (var wResponse = req.GetResponse())
            {
                using (StreamReader readStream = new StreamReader(wResponse.GetResponseStream()))
                {
                    string responseFromServer = readStream.ReadToEnd();
                    if (!responseFromServer.Contains("\"success\": false"))
                        return true;
                }
            }
            return false;
            
        }
