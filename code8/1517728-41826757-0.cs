    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication43
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME);
                //pass one create cube and inputs
                foreach(XElement cube in  doc.Descendants("CUBE"))
                {
                    Cube newCube = new Cube();
                    Cube.cubes.Add(newCube);
                    newCube.name = (string)cube.Attribute("NAME");
                    newCube.sides = cube.Elements("IN").Select(y => new Side() {
                        name = (string)y.Attribute("NAME"),
                        _in = newCube
                    }).ToList();
                }
                foreach (XElement xCube in doc.Descendants("CUBE"))
                {
                    string outCubeName = (string)xCube.Attribute("NAME");
                    Cube outCube = Cube.cubes.Where(x => x.name == outCubeName).FirstOrDefault();
                    foreach(XElement _out in xCube.Elements("OUT"))
                    {
                        string sideName = (string)_out.Attribute("NAME");
                        Boolean found = false;
                        foreach (Cube inCube in Cube.cubes)
                        {
                            foreach (Side side in inCube.sides)
                            {
                                if (side.name == sideName)
                                {
                                    side._out = outCube;
                                    found = true;
                                    break;
                                }
                            }
                            if (found == true) break;
                        }
                    }
                }
     
            }
        }
        public class Cube
        {
            public static List<Cube> cubes = new List<Cube>();
            public string name { get; set; }
            public List<Side> sides { get; set; }
        }
        public class Side
        {
            public string name { get; set; }
            public Cube _in { get; set; }
            public Cube _out { get; set; }
        }
    }
