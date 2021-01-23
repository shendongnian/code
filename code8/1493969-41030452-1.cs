    static int HexToInt (char hexChar)
	{
		hexChar = char.ToUpper (hexChar);
		return (int)hexChar < (int)'A' ?
			((int)hexChar - (int)'0') :
			10 + ((int)hexChar - (int)'A');
	}
	public static string Decode (string s)
	{
		var result = new StringBuilder ();
		for (int i = 0; i < s.Length; i++) {
			char ch = s [i];
			if (ch == '&') {
				ch = Convert.ToChar (HexToInt (s [i + 3]) * 16 +
									 HexToInt (s [i + 4]));
				i += 5;
			}
			result.Append (ch);
		}
		return result.ToString ();
	}
