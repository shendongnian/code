    using System.Collections.ObjectModel;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication57
    {
        class Program
        {
            const string URL = "http://goalserve.com/samples/soccer_inplay.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(URL);
                Localteam.teams = doc.Descendants("odd").Select(x => new Localteam()
                {
                    Name = (string)x.Attribute("name"),
                    games = x.Elements("type").Where(y => y.Attribute("id") != null).Select(y => new Game() {
                        id = (long)y.Attribute("id"),
                        opponent = (string)y.Attribute("name"),
                        suspend = (int)y.Attribute("suspend"),
                        odd = (Single)y.Attribute("odd"),
                        _type = (string)y.Attribute("type")
                    }).ToList()
                }).ToList();
            }
        }
        public class Localteam
        {
            public static List<Localteam> teams = new List<Localteam>();
            public string Name { get; set; }
            public List<Game> games { get; set; }
        }
        public class Game
        {
            public string opponent { get; set; }
            public long id { get; set; }
            public int suspend { get; set; }
            public Single odd { get; set; }
            public string _type { get; set; }
        }
    }
