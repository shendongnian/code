    using System;
    using System.Globalization;
    using System.IO;
    using System.Text.RegularExpressions;
    
    namespace ConsoleApplication1
    {
    	class Program
    	{
    		static void Main(string[] args)
    		{
    
    			string inFile = @"C:\temp\sampledata.txt";
    			string outFile = @"C:\temp\sampledata.csv";
    
    			//<one> catpures the date data:
    			Regex re = new Regex(@"(?<one>[0-9]{2}-[0-9]{2}-[0-9]{2})\s{1,20}114B\s{1,15}(?<two>\d{1,11})\s{1,15}(?<three>\d{1,11})\s{1,15}(?<four>\d{1,11})\s{1,30}(?<five>\d{1,11})");
    
    			using (var sr = new StreamReader(inFile))
    			{
    				using (var sw = new StreamWriter(outFile))
    				{
    					string line1;
    					DateTime dt;
    					var ci = new CultureInfo("ur-PK");
    					while (!sr.EndOfStream)
    					{
    						line1 = sr.ReadLine();
    						MatchCollection matches = re.Matches(line1);
    						foreach (Match m in matches)
    						{
    							dt = DateTime.Parse(m.Groups["one"].Value, ci);
    							sw.Write(dt.ToString("yyyy-MM-dd") + ",");
    							sw.Write(m.Groups["two"].Value + ",");
    							sw.Write(m.Groups["three"].Value + ",");
    							sw.Write(m.Groups["four"].Value + ",");
    							sw.Write(m.Groups["five"].Value + Environment.NewLine);
    						}
    					}
    				}
    			}
    		}
    	}
    }
