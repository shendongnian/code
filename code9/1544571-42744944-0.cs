	Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture("da-DK");
	DateTime dt = DateTime.Now;
	Console.WriteLine($"{dt.ToLongDateString()} {dt.ToLongTimeString()}");
	Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture("en-US");
	Console.WriteLine($"{dt.ToLongDateString()} {dt.ToLongTimeString()}");
	Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture("ar-AE");
	Console.WriteLine($"{dt.ToLongDateString()} {dt.ToLongTimeString()}");
	Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture("zh-CN");
	Console.WriteLine($"{dt.ToLongDateString()} {dt.ToLongTimeString()}");
