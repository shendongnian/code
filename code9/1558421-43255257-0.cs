    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication49
    {
       
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME);
                var results = doc.Descendants("ImageMetadata").Select(x => new
                {
                    colorHistograms = x.Descendants("ColorHistogram").Select(y => new
                    {
                        bin = y.Elements("Bin").Select(z => new
                        {
                            value = (int)z.Attribute("value")
                        }).ToList()
                    }).FirstOrDefault(),
                    faceLocations = x.Descendants("FaceLocations").Select(y => new
                    {
                        facePosition = y.Elements("FacePosition").Select(z => new
                        {
                            X = (int)z.Attribute("X"),
                            Y = (int)z.Attribute("Y")
                        }).ToList()
                    }).FirstOrDefault()
                }).FirstOrDefault();
                
            }
        }
     
       
    }
