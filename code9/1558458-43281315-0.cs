    using NetOffice.ExcelApi.Enums;
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Linq;
    using Excel = NetOffice.ExcelApi;
    namespace _43248441
    {
        class Program
        {
            static void Main(string[] args)
            {
                using (var app = Excel.Application.GetActiveInstance())
                {
                    var workbook = app.ActiveWorkbook;
                    var sheet = (Excel.Worksheet)workbook.ActiveSheet;
                    var range1 = sheet.Cells[1, 1];
                    var range2 = sheet.Cells[1, 3];
                    //our range is only 1 cell in this case, so we get the first cell and its style
                    var xml1 = (string)range1.get_Value(rangeValueDataType: XlRangeValueDataType.xlRangeValueXMLSpreadsheet);
                    var doc1 = XDocument.Parse(xml1, LoadOptions.PreserveWhitespace); //Make sure to preserve whitespace
                    var firstCell1 = doc1.Descendants().FirstOrDefault(n => n.Name.LocalName == "Cell");
                    var style1 = GetStyleForCell(firstCell1, doc1);
                    //same here
                    var xml2 = (string)range2.get_Value(rangeValueDataType: XlRangeValueDataType.xlRangeValueXMLSpreadsheet);
                    var doc2 = XDocument.Parse(xml2, LoadOptions.PreserveWhitespace);
                    var firstCell2 = doc2.Descendants().FirstOrDefault(n => n.Name.LocalName == "Cell");
                    var style2 = GetStyleForCell(firstCell2, doc2);
                    //check if the second XDocument already contains a style with the same name as the first cell's
                    var sameStyle2 = GetStyleById(doc2, style1.Item2);
                    var style2container = style2.Item1.Parent;
                    //remove the style if it exists
                    if (sameStyle2 != null)
                        sameStyle2.Remove();
                    //add a clone of cell1's style
                    style2container.Add(new XElement(style1.Item1));
                    //Apply attribute reference
                    var styleId2 = firstCell2.Attributes().FirstOrDefault(a => a.Name.LocalName == "StyleID");
                    if (styleId2 == null) {
                        firstCell2.Add(new XAttribute(firstCell1.Attributes().First(a =>  a.Name.LocalName == "StyleID")));
                    }
                    else
                    {
                        styleId2.Value = style1.Item2;
                    }
                    
                    range2.set_Value(XlRangeValueDataType.xlRangeValueXMLSpreadsheet, doc2.GetString());
                    Console.ReadLine();
                }
            }
            private static Tuple<XElement, string> GetStyleForCell(XElement cell, XDocument document)
            {
                var styleId = cell.Attributes().FirstOrDefault(a => a.Name.LocalName == "StyleID")?.Value ?? "Default";
                return new Tuple<XElement, string>(GetStyleById(document, styleId), styleId);
            }
            private static XElement GetStyleById(XDocument document, string styleId)
            {
                var styles = document.Descendants().FirstOrDefault(n => n.Name.LocalName == "Styles").Elements().Where(s => s.Name.LocalName == "Style");
                var style = styles.FirstOrDefault(s => s.Attributes().FirstOrDefault(a => a.Name.LocalName == "ID")?.Value == styleId);
                return style;
            }
        }
        public static class XDocumentEx
        {
            //This method makes sure nothing has happened with the formatting of the XML
            public static string GetString(this XDocument doc)
            {
                var builder = new StringBuilder();
                using (var writer = new StringWriter(builder))
                {
                    doc.Save(writer);
                }
                return builder.ToString();
            }
        }
    }
