    double valueOne;
	double valueTwo;
	String[] s = str.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
	valueOne = double.Parse(s[0], System.Globalization.CultureInfo.InvariantCulture);
	valueOne = double.Parse(s[1], System.Globalization.CultureInfo.InvariantCulture);
