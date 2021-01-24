		public static string Decrypt1(string s)
		{
			string functionReturnValue = null;
			if (string.IsNullOrEmpty(s))
			{
				functionReturnValue = "";
			}
			else
			{
				string r = null;
				int ch = null;
				for (int i = 0; i < s.Length / 2; i++)
				{
					ch = int.Parse(s.Substring((i) * 2, 2), NumberStyles.AllowHexSpecifier);
					ch = ch ^ 111;
					r = r + (char)(ch);
				}
				var charArray = r.ToCharArray();
				Array.Reverse(charArray);
				functionReturnValue = new string(charArray);
			}
			return functionReturnValue;
		}
