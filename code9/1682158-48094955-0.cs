	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;
	using HtmlAgilityPack;
	namespace ConsoleApp3
	{
		class Program
		{
			static void Main(string[] args)
			{
				string html = @"<article>
								  <div class=""inner-article"">
									<h1>
									<a class=""name-link"" href=""shop.com/7689"">Cool Jacket</a>
									</h1>
									<p>
									<a class=""name-link"" href=""shop.com/7689"">Pink</a>
									</p>
								  </div>
								</article>
								<article>
								  <div class=""inner-article"">
									<h1>
									<a class=""name-link"" href=""shop.com/5432"">Cool jacket</a>
									</h1>
									<p>
									<a class=""name-link"" href=""shop.com/5432"">Black</a>
									</p>
								  </div>
								</article>
								<article>
								  <div class=""inner-article"">
									<h1>
									<a class=""name-link"" href=""shop.com/2342"">Really cool pants </a>
									</h1>
									<p>
									<a class=""name-link"" href=""shop.com/2342"">Green</a>
									</p>
								  </div>
								</article>";
				string productName = "Cool jacket";
				string color = "Black";
				HtmlDocument htmlDoc = new HtmlDocument();
				htmlDoc.LoadHtml(html);
				var node = htmlDoc.DocumentNode.SelectSingleNode(
					$"//a[@class='name-link' and text()='{color}' and preceding::*/a[@class='name-link' and text()='{productName}']]");
				Console.WriteLine($"href: {node.GetAttributeValue("href","")}");
				Console.ReadKey();
			}
		}
	}
