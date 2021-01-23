    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME);
                var pokemon = doc.Descendants("Pokemon").Select(x => new {
                    name = (string)x.Element("Name"),
                    health = (int)x.Element("BaseStats").Element("Health"),
                    attack = (int)x.Element("BaseStats").Element("Attack"),
                    defense = (int)x.Element("BaseStats").Element("Defense"),
                    specialAttack = (int)x.Element("BaseStats").Element("SpecialAttack"),
                    specialDefense = (int)x.Element("BaseStats").Element("SpecialDefense"),
                    speed = (int)x.Element("BaseStats").Element("Speed"),
                }).FirstOrDefault();
            }
        }
    }
