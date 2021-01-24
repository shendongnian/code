	private string GetAuthCode(string CodeType)
	{
		var patterns = new Dictionary<char, Func<Char>>()
		{
			{ '9', () => RandomBytes().Where(x => x >= '0' && x <= '9').First() },
			{ 'A', () => RandomBytes().Where(x => x >= 'A' && x <= 'Z').First() },
			{ '-', () => '-' },
		};
		
		return
			String.IsNullOrEmpty(CodeType)
				? ""
				: patterns[CodeType[0]]().ToString() + GetAuthCode(CodeType.Substring(1));
	}
	
	private IEnumerable<char> RandomBytes()
	{
		using (var rng = System.Security.Cryptography.RNGCryptoServiceProvider.Create())
		{
			var bytes = new byte[256];
			while (true)
			{
				rng.GetBytes(bytes);
				foreach (var @byte in bytes)
				{
					yield return (char)@byte;
				}
			}
		}
	}
