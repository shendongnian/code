    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string URL = "https://pastebin.com/raw/Ch1BeS0k";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(URL);
                XElement root = doc.Root;
                XNamespace ns = root.GetDefaultNamespace();
                var results = root.Descendants(ns + "DataObject").Select(dataObject => new
                {
                    hourGroups = dataObject.Descendants(ns + "HourGroup").Select(hourGroup => new
                    {
                        logEvents = hourGroup.Descendants(ns + "LogEvent").Select(logEvent => new
                        {
                            date = (DateTime)dataObject.Element(ns + "Date"),
                            hour = (int)hourGroup.Element(ns + "Hour"),
                            time = (string)logEvent.Descendants(ns + "Time").FirstOrDefault(),
                            runtime = (string)logEvent.Descendants(ns + "Runtime").FirstOrDefault(),
                            displayText = (logEvent.Element(ns + "AssetEvent") != null) && (logEvent.Descendants(ns + "Runtime").Any()) ? (string)logEvent.Descendants(ns + "DisplayText").FirstOrDefault() : string.Empty
                        }).ToList()
                    }).SelectMany(x => x.logEvents)
                }).SelectMany(x => x.hourGroups).ToList();
                int minute = 0;
                string pattern = @"PT(?'minutes'\d+)M";
                foreach (var result in results)
                {
                    if (result.time != null)
                    {
                        minute = int.Parse(Regex.Match(result.time, pattern).Groups["minutes"].Value);
                    }
                    if (result.displayText.Contains("COMMERCIAL BREAK"))
                    {
                        Console.WriteLine("C{0}{1}         {2}", result.hour.ToString("00"), minute.ToString("00"), result.displayText);
                    }
                }
                Console.ReadLine();
            }
        }
    }
