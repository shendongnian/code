    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;
    using System.Text;
    using System.Threading.Tasks;
    namespace ConsoleApplication9
    {
      class Program
      {
        static void Main(string[] args)
        {
            string xmlstring = @"<MapFile>
                                     <Import>
                                      <field name1=""BorrowId"" name2=""EMPLID"" />
                                      <field name1=""Firstname"" name2=""COMPLETENAME"" />
                                      <field name1=""Address"" name2=""Address"" Reference=""Location"" />
                                     </Import>
                                     <Location>
                                      <Lookup Key=""CC"" Replace=""1"" />
                                      <Lookup Key=""CE"" Replace=""2"" />
                                     </Location>
                                    </MapFile>";
            XElement xmlTree = XElement.Parse(xmlstring);
            ParseChildElement(xmlTree);
            Console.ReadLine();
        }
        static void ParseChildElement(XElement xmlTree)
        {
            PrintAttributes(xmlTree);
            foreach(XElement element in xmlTree.Elements())
            {
                ParseChildElement(element);
            }
        }
        static void PrintAttributes(XElement xmlTree)
        {
            foreach (XAttribute attr in xmlTree.Attributes())
            {
                string[] attribArray = attr.ToString().Split('=');
                if (attribArray.Length > 1)
                    Console.WriteLine(string.Format(@" {0} = {1}", attr.Name, attr.Value));
            }
        }
    }
}
