    public DateTime GetInternetTime()
        {
            var myHttpWebRequest = (HttpWebRequest)WebRequest.Create("http://www.microsoft.com");
            myHttpWebRequest.Timeout = 5000;
            myHttpWebRequest.ReadWriteTimeout = 5000;
            try
            {
                var response = myHttpWebRequest.GetResponse();
                string todaysDates = response.Headers["date"];
                dateTime = DateTime.ParseExact(todaysDates, "ddd, dd MMM yyyy HH:mm:ss 'GMT'", CultureInfo.InvariantCulture.DateTimeFormat, DateTimeStyles.AssumeUniversal);
                connectionFailed = false;
            } catch(WebException)
            {
                connectionFailed = true;
                dateTime = DateTime.Now;
            }
            return dateTime;
        }
