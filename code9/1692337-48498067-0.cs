    private static DateTime GetDateTime(string dateString){
            DateTime res = new DateTime();
            if(DateTime.TryParse(dateString, System.Globalization.CultureInfo.GetCultureInfo("en-GB"),
    System.Globalization.DateTimeStyles.None, out res))
                return res;
            else if(DateTime.TryParse(dateString, System.Globalization.CultureInfo.GetCultureInfo("en-US"),
    System.Globalization.DateTimeStyles.None, out res))
                return res;
            else if(DateTime.TryParse(dateString, System.Globalization.CultureInfo.GetCultureInfo("fr-FR"),
    System.Globalization.DateTimeStyles.None, out res))
                return res;
            else if(DateTime.TryParse(dateString, System.Globalization.CultureInfo.GetCultureInfo("de-DE"),
    System.Globalization.DateTimeStyles.None, out res))
                return res;
            //throw error or handle the not matcing case here
             Console.WriteLine("Not Matching "+dateString);           
            return res;
        }
