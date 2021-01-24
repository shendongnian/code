	static public class ExtensionMethods
	{
		static public string CaesarShift(this string input, int offset)
		{
			const string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
			return new string
			(
				input.Select 
				(
					c =>
					{ 
						var index = alphabet.IndexOf(c);
						return index == -1 
							? c
							: alphabet[(index + offset + alphabet.Length) % alphabet.Length];
					}
				
				).ToArray()
			);
		}
	}
	
	public class Program
	{
	
		public static void Main()
		{
			var word = "THE QUICK RED FOX JUMPS OVER THE LAZY BROWN DOG. the quick red fox jumps over the lazy brown dog. 123456789!(*&#*";
			
			var encoded = word.CaesarShift(3);
			Console.WriteLine(encoded);
	
			var decoded = encoded.CaesarShift(-3);
			Console.WriteLine(decoded);
		}
	}
