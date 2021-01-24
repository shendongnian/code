            System.Globalization.CultureInfo customCulture = new System.Globalization.CultureInfo("da-DK", true);
             //to change the date time patern
            //customCulture.DateTimeFormat.ShortDatePattern = "yyyy-MM-dd h:mm tt";
            System.Threading.Thread.CurrentThread.CurrentCulture = customCulture;
            System.Threading.Thread.CurrentThread.CurrentUICulture = customCulture;
            DateTime newDate = System.Convert.ToDateTime("Tue, 13 Jun 2017 07:44:58 GMT");
