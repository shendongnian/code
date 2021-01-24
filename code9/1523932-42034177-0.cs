	public string Decrypt1(string s)
		{
			string functionReturnValue = null;
			if (string.IsNullOrEmpty(s))
			{
				functionReturnValue = "";
			}
			else
			{
				string r = null;
				dynamic ch = null;
				for (int i = 1; i <= s.Length / 2; i++)
				{
					ch = "&H" + s.Substring((i - 1) * 2 + 1, 2);
					ch = ch ^ 111;
					r = r + (char)(ch);
				}
				var charArray = r.ToCharArray();
				Array.Reverse(charArray);
				functionReturnValue = new string(charArray);
			}
			return functionReturnValue;
		}
