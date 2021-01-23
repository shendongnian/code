      Can you please try this on app_start I hope it is helpful.
      
      DateTime dt = DateTime.Now;
      // Sets the CurrentCulture property to U.S. English.
      Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
      // Displays dt, formatted using the ShortDatePattern
      // and the CurrentThread.CurrentCulture.
      Console.WriteLine(dt.ToString("d"));
      
      // Creates a CultureInfo for German in Germany.
      CultureInfo ci = new CultureInfo("de-DE");
      // Displays dt, formatted using the ShortDatePattern
      // and the CultureInfo.
      Console.WriteLine(dt.ToString("d", ci));
