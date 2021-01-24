        static void Main(string[] args)
		{
			Console.WriteLine();
			int brand;
			string _val = "";
			Console.Write("Enter number: ");
			while(true)
			{
				var key = Console.ReadKey(true);
				if (key.Key == ConsoleKey.Enter && int.TryParse(_val, out brand))
				{
					Console.WriteLine();
					break;
				}
				if (key.Key != ConsoleKey.Backspace)
				{
					int val;
					if (int.TryParse(key.KeyChar.ToString(), out val))
					{
						_val += key.KeyChar;
						Console.Write(key.KeyChar);
					}
				}
				else
				{
					if (_val.Length > 0)
					{
						_val = _val.Substring(0, _val.Length - 1);
						Console.Write("\b \b");
					}
				}
			}
			Console.WriteLine("Brand: {0}", brand);
			Console.ReadKey();
		}
