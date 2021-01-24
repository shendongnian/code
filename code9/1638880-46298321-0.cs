    private void UpdateCurrentCulture()
		{
			System.Globalization.CultureInfo objCulture = new System.Globalization.CultureInfo("en-US");
			objCulture.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy";
			objCulture.DateTimeFormat.ShortTimePattern = "hh:mm tt";
			System.Threading.Thread.CurrentThread.CurrentCulture = objCulture;
			System.Threading.Thread.CurrentThread.CurrentUICulture = objCulture;
			Console.WriteLine(DateTime.Now.ToShortDateString());
			Console.WriteLine(DateTime.Now.ToShortTimeString());
		}
