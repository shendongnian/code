    using NetOffice.ExcelApi.Enums;
    using System;
    using System.Linq;
    using System.Xml.Linq;
    using System.Drawing;
    using Excel = NetOffice.ExcelApi;
    namespace S_43139465
    {
        class Program
        {
            static void Main(string[] args)
            {
                using (var app = Excel.Application.GetActiveInstance())
                {
                    var range = (Excel.Range)app.Selection;
                    var xml = (string)range.get_Value(rangeValueDataType: XlRangeValueDataType.xlRangeValueXMLSpreadsheet);
                    var colors = XDocument.Parse(xml)
                                          .Descendants().First(n => n.Name.LocalName == "Styles")
                                          .Descendants().Where(n => n.Name.LocalName == "Interior")
                                          .Select(i => i.Attributes().FirstOrDefault(a => a.Name.LocalName == "Color"))
                                          .Where(a => a != null)
                                          .Select(a => a.Value)
                                          .Distinct()
                                          .Select(s => ColorTranslator.FromHtml(s));
                    foreach (var color in colors)
                    {
                        Console.WriteLine(color);
                    }
                }
                Console.ReadLine();
            }
        }
    }
