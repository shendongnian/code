    using System;
    using System.Xml.Linq;
    
    namespace SO39545160
    {
      class Program
      {
        static string xmlSource = "<soap:Envelope xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">" +
          "<soap:Body>" +
          "<MyResponse xmlns = \"https://www.domain.net/\" >" +
          "<Node1 > 0 </Node1 >" +
          "</MyResponse>" +
          "</soap:Body>" +
          "</soap:Envelope>";
    
        static void Main(string[] args)
        {
          XDocument xdoc = XDocument.Parse(xmlSource);
          var subXml = xdoc.Document.Elements(XName.Get(@"{http://schemas.xmlsoap.org/soap/envelope/}Envelope")).Elements(XName.Get(@"{http://schemas.xmlsoap.org/soap/envelope/}Body")).Elements(XName.Get(@"{https://www.domain.net/}MyResponse"));
    
          foreach (var node in subXml)
          {
            XDocument myRespDoc = new XDocument(node);
            Console.WriteLine(myRespDoc);
          }
          Console.WriteLine();
    
          Console.WriteLine("END");
          Console.ReadLine();
        }
      }
    }
