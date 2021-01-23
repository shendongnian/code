    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication29
    {
        class Program
        {
            static void Main(string[] args)
            {
                var ExportModelMachetas = new object[][] {
                    new object[] { "ufImportProduesPrioritateXContactare", "IdArticol", "string", "1"},
                    new object[] { "ufImportProduesPrioritateXContactare", "Prioritate", "string", "2"},
                    new object[] { "ufImportExcelCaracteristiciUtilizatorXContactare", "IdUtilizator", "string", "1"},
                    new object[] { "ufImportExcelCaracteristiciUtilizatorXContactare", "IdLocatie", "string", "2"},
                    new object[] { "ufImportExcelCaracteristiciUtilizatorXContactare", "TipUtilizator", "string", "3"}
                };
                List<XElement> results = ToXML(ExportModelMachetas); 
     
            }
            static List<XElement> ToXML(object[][] ExportModelMachetas)
            {
                List<XElement> results = new List<XElement>();
                foreach (var ExportModelMacheta in ExportModelMachetas)
                {
                    XElement newExportModelMacheta = new XElement("ExportModelMacheta", new object[] {
                        new XAttribute("Macheta", ExportModelMacheta[0]),
                        new XAttribute("NumeColoana", ExportModelMacheta[2]),
                        new XAttribute("TipDeDate", ExportModelMacheta[2]),
                        new XAttribute("Pozitie", ExportModelMacheta[3]),
                        new XAttribute("FromatMacheta", "xls"),
                    });
                    results.Add(newExportModelMacheta);
                }
                return results;
            }
        }
    }
