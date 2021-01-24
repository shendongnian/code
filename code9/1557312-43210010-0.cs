    void Application_BeginRequest(Object sender, EventArgs e)
    {
         string langCode = "en";  //default
        
         if (somecondition)
              langCode = "au";
         System.Threading.Thread.CurrentThread.CurrentUICulture = System.Globalization.CultureInfo.GetCultureInfo(langCode);
         System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture(langCode);
    }
