    using System;
    using System.IO;
    using System.Linq;
    using System.Xml.Linq;
    namespace XmlTest
    {
        class Program
        {
            static void Main(string[] args)
            {
                var xmlText = @"
    <Reservedele>
      <Component>
        <Type>Støvsuger</Type>
        <Art>yiryidryi</Art>
        <Bemærkning> adadgadg</Bemærkning>
        <Varenummer>dfgdfg</Varenummer>
        <OprettetAf>John</OprettetAf>
        <Date>28. januar 2017</Date>
      </Component>
    </Reservedele>";
                using (var sr = new StringReader(xmlText))
                {
                    var xml = XElement.Load(sr);
                    var noprovider = xml.Elements("Component").Where(d => !d.Elements("L").Any());
                    noprovider.Elements().ElementAt(1).AddAfterSelf(new XElement("L", ""));
                    //noprovider.Elements("Art").First().AddAfterSelf(new XElement("L", ""));
                    Console.WriteLine(xml.ToString());
                }
                Console.WriteLine("\nPress any key ...");
                Console.ReadKey();
            }
        }
    }
