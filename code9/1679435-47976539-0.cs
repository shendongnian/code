    using (WebClient webClient = new WebClient())
    {
    	webClient.Credentials = new NetworkCredential(username, password); //set username and password here
    	webClient.DownloadFile("http://gis.abc.org.pk/report.php", Server.MapPath("~/App_Data/TempData/DataFile/Data.csv"));
    }
