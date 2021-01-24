    using System;
						
	public class Program
	{
		public static void Main()
		{
			string htmlPageContent = "Some HTML <br> DefaultStyle.css?x=839ua9";
			string pageContent = "";
			
			System.Text.RegularExpressions.Regex regEx = null;
	
            //regEx = new System.Text.RegularExpressions.Regex("DefaultStyle.css?x=839ua9");
			regEx = new System.Text.RegularExpressions.Regex(@"DefaultStyle\.css\?x=839ua9");
			pageContent = regEx.Replace(htmlPageContent, "DefaultStyleSnap.css?x=742zh2");
			
			Console.WriteLine(pageContent);
		}
	}
