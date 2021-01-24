    using System;
    using System.Text.RegularExpressions;
   
    class Program {
		static void Main() {
			string text = "this is my text";
			Regex rx = new Regex(@"\b(\w)");
			string result = rx.Replace(text, (Match m) => {
					return m.ToString().ToUpper().ToString();
			} );
			Console.WriteLine(result);// "This Is My Text"
			Console.ReadKey();
		}
    }
