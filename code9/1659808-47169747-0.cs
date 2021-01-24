    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Net;
    namespace GoogleFinanceDataScraper
    {
        class Program
        {
            static void Main(string[] args)
            {
                WebClient web = new WebClient();
                string page = web.DownloadString("https://finance.google.com/finance/historical?q=NYSE:C&ei=7O4nV9GdJcHomAG02L_wCw");
                HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                doc.LoadHtml(page);
                var node = doc.DocumentNode.SelectSingleNode("//div[@id='prices']/table");
                string outerHtml = node.OuterHtml;
                List<String> data = new List<string>();
                using(StringReader reader = new StringReader(outerHtml))
                {
                    for(int i = 0; ; i++)
                    {
                        var line = reader.ReadLine();
                        if (i < 9) continue;
                        else if (i < 15)
                        {
                            var dataRawArray = line.Split(new char[] { '>' });
                            var value = dataRawArray[1];
                            data.Add(value);
                        }
                        else break;
                    }
                }
                Console.WriteLine($"{data[0]}, {data[1]}, {data[2]}, {data[3]}, {data[4]}, {data[5]}");
            }
        }
    }
