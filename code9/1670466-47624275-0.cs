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
            const string FILENAME = @"c:\temp\text.xml";
            static void Main(string[] args)
            {
                string input = "This is some text with first token &*T1& and the second token &*T1001& and more tokens &*SomeValue& and still more &*A2ndValue&.";
                XDocument doc = XDocument.Load(FILENAME);
                string patternToken = "&[^&]+&";
                string patternTag = @"&\*(?'tag'[^&]+)&";
                MatchCollection  matches = Regex.Matches(input, patternToken);
                foreach(Match match in matches.Cast<Match>())
                {
                    string token = match.Value;
                    string tag = Regex.Match(token, patternTag).Groups["tag"].Value;
                    string tagValue = doc.Descendants(tag).Select(x => (string)x).FirstOrDefault();
                    input = input.Replace(token, tagValue);
                }
            }
        }
    }
