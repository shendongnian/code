    using System.Globalization;
    using System.Threading;
    
    //...
    protected void Application_BeginRequest(Object sender, EventArgs e)
    {    
      CultureInfo newCulture = (CultureInfo) System.Threading.Thread.CurrentThread.CurrentCulture.Clone();
      newCulture.DateTimeFormat.ShortDatePattern = "dd/MMM/yyyy";
      newCulture.DateTimeFormat.DateSeparator = "/";
      Thread.CurrentThread.CurrentCulture = newCulture;
    }
