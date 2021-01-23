    		System.Diagnostics.Debug.WriteLine("Received: " + str);
			String[] s = str.Split(new char[] { '|' });
			int index = int.Parse(s[0]);
			if (index == 1) {
				valueOne = double.Parse(s[1], System.Globalization.CultureInfo.InvariantCulture);
			}
			else if (index == 2) {
				valueTwo = double.Parse(s[1], System.Globalization.CultureInfo.InvariantCulture);
			}
			System.Diagnostics.Debug.WriteLine(valueOne);
			System.Diagnostics.Debug.WriteLine(valueTwo);
