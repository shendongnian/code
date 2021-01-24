		public static string Decrypt1(string s)
		{
			if (string.IsNullOrEmpty(s))
				return string.Empty;
			string r = null;
			for (int i = 1; i <= s.Length / 2; i++)
			{
				var ch = Convert.ToUInt32(s.Substring((i - 1) * 2, 2), 16);
				ch = ch ^ 111;
				r = r + (char)(ch);
			}
			var charArray = r.ToCharArray();
			Array.Reverse(charArray);
			return new string(charArray);
		}
