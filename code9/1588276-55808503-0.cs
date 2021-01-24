    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;
    
    namespace SVGRead
    {
        class Program
        {
            static void Main(string[] args)
            {
                string filePath = AppDomain.CurrentDomain.BaseDirectory + "test.svg";
                XDocument doc = XDocument.Load(filePath);
                XElement rootElements = doc.Root;
                IEnumerable<XElement> nodes = from element1 in rootElements.Elements("{http://www.w3.org/2000/svg}g") select element1;
                foreach (var node in nodes)
                {
                    IEnumerable<XElement> childNodes = from element2 in node.Elements("{http://www.w3.org/2000/svg}rect") select element2;
                    foreach (var childNod in childNodes)
                    {
                        //Get child of <g>, ract tag
                        string txtRect = childNod.ToString();
    
                        //Get Attribute values like "style", "width", "height", etc..
                        string style = childNod.Attribute("style").Value;
                        string width = childNod.Attribute("width").Value;
                        string height = childNod.Attribute("height").Value;
                    }
                }
            }
        }
    }
