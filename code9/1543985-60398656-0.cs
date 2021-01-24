    using System.Linq;
    using DocumentFormat.OpenXml.Packaging;
    using DocumentFormat.OpenXml.Spreadsheet;
    using DocumentFormat.OpenXml;
    using System.Drawing;
    using System.IO;
    using System.Drawing.Imaging;
    using System;
    namespace WindowsFormsApplication2
    {
        public class GeneratedClass
        {
            private static System.Collections.Generic.IDictionary<System.String, OpenXmlPart> UriPartDictionary = new System.Collections.Generic.Dictionary<System.String, OpenXmlPart>();
            private static System.Collections.Generic.IDictionary<System.String, DataPart> UriNewDataPartDictionary = new System.Collections.Generic.Dictionary<System.String, DataPart>();
            private static SpreadsheetDocument document;
            public static void ChangePackage(string filePath)
            {
                using (document = SpreadsheetDocument.Open(filePath, true))
                {
                    ChangeParts();
                }
            }
            private static void ChangeParts()
            {
                //Stores the referrences to all the parts in a dictionary.
                BuildUriPartDictionary();
                //Adds new parts or new relationships.
                AddParts();
                //Changes the contents of the specified parts.
                ChangeCoreFilePropertiesPart1(((CoreFilePropertiesPart)UriPartDictionary["/docProps/core.xml"]));
                ChangeWorksheetPart1(((WorksheetPart)UriPartDictionary["/xl/worksheets/sheet1.xml"]));
            }
            /// <summary>
            /// Stores the references to all the parts in the package.
            /// They could be retrieved by their URIs later.
            /// </summary>
            private static void BuildUriPartDictionary()
            {
                System.Collections.Generic.Queue<OpenXmlPartContainer> queue = new System.Collections.Generic.Queue<OpenXmlPartContainer>();
                queue.Enqueue(document);
                while (queue.Count > 0)
                {
                    foreach (var part in queue.Dequeue().Parts)
                    {
                        if (!UriPartDictionary.Keys.Contains(part.OpenXmlPart.Uri.ToString()))
                        {
                            UriPartDictionary.Add(part.OpenXmlPart.Uri.ToString(), part.OpenXmlPart);
                            queue.Enqueue(part.OpenXmlPart);
                        }
                    }
                }
            }
            /// <summary>
            /// Adds new parts or new relationship between parts.
            /// </summary>
            private static void AddParts()
            {
                //Generate new parts.
                VmlDrawingPart vmlDrawingPart1 = UriPartDictionary["/xl/worksheets/sheet1.xml"].AddNewPart<VmlDrawingPart>("rId2");
                GenerateVmlDrawingPart1Content(vmlDrawingPart1);
                ImagePart imagePart1 = vmlDrawingPart1.AddNewPart<ImagePart>("image/png", "rId1");
                GenerateImagePart1Content(imagePart1);
            }
            private static void GenerateVmlDrawingPart1Content(VmlDrawingPart vmlDrawingPart1)
            {
                System.Xml.XmlTextWriter writer = new System.Xml.XmlTextWriter(vmlDrawingPart1.GetStream(System.IO.FileMode.Create), System.Text.Encoding.UTF8);
                writer.WriteRaw("<xml xmlns:v=\"urn:schemas-microsoft-com:vml\"\r\n xmlns:o=\"urn:schemas-microsoft-com:office:office\"\r\n xmlns:x=\"urn:schemas-microsoft-com:office:excel\">\r\n <o:shapelayout v:ext=\"edit\">\r\n  <o:idmap v:ext=\"edit\" data=\"1\"/>\r\n </o:shapelayout><v:shapetype id=\"_x0000_t75\" coordsize=\"21600,21600\" o:spt=\"75\"\r\n  o:preferrelative=\"t\" path=\"m@4@5l@4@11@9@11@9@5xe\" filled=\"f\" stroked=\"f\">\r\n  <v:stroke joinstyle=\"miter\"/>\r\n  <v:formulas>\r\n   <v:f eqn=\"if lineDrawn pixelLineWidth 0\"/>\r\n   <v:f eqn=\"sum @0 1 0\"/>\r\n   <v:f eqn=\"sum 0 0 @1\"/>\r\n   <v:f eqn=\"prod @2 1 2\"/>\r\n   <v:f eqn=\"prod @3 21600 pixelWidth\"/>\r\n   <v:f eqn=\"prod @3 21600 pixelHeight\"/>\r\n   <v:f eqn=\"sum @0 0 1\"/>\r\n   <v:f eqn=\"prod @6 1 2\"/>\r\n   <v:f eqn=\"prod @7 21600 pixelWidth\"/>\r\n   <v:f eqn=\"sum @8 21600 0\"/>\r\n   <v:f eqn=\"prod @7 21600 pixelHeight\"/>\r\n   <v:f eqn=\"sum @10 21600 0\"/>\r\n  </v:formulas>\r\n  <v:path o:extrusionok=\"f\" gradientshapeok=\"t\" o:connecttype=\"rect\"/>\r\n  <o:lock v:ext=\"edit\" aspectratio=\"t\"/>\r\n </v:shapetype><v:shape id=\"LH\" o:spid=\"_x0000_s1025\" type=\"#_x0000_t75\"\r\n  style=\';margin-left:0;margin-top:0;width:207pt;height:156pt;\r\n  z-index:1\'>\r\n  <v:imagedata o:relid=\"rId1\" o:title=\"WOPI\"/>\r\n  <o:lock v:ext=\"edit\" rotation=\"t\"/>\r\n </v:shape></xml>");
                writer.Flush();
                writer.Close();
            }
            private static void GenerateImagePart1Content(ImagePart imagePart1)
            {
                Image image = Image.FromFile(@"C:\Users\Administrator\Desktop\Capture.PNG");
                using (MemoryStream stream = new MemoryStream())
                {
                    // Save image to stream.
                    image.Save(stream, ImageFormat.Png);
                    string imagePart1Data = Convert.ToBase64String(stream.ToArray());
                    System.IO.Stream data = GetBinaryDataStream(imagePart1Data);
                    imagePart1.FeedData(data);
                    data.Close();
                }    
            }
            private static void ChangeCoreFilePropertiesPart1(CoreFilePropertiesPart coreFilePropertiesPart1)
            {
                var package = coreFilePropertiesPart1.OpenXmlPackage;
                package.PackageProperties.Modified = System.Xml.XmlConvert.ToDateTime("2015-07-30T03:03:22Z", System.Xml.XmlDateTimeSerializationMode.RoundtripKind);
            }
            private static void ChangeWorksheetPart1(WorksheetPart worksheetPart1)
            {
                Worksheet worksheet1 = worksheetPart1.Worksheet;
                HeaderFooter headerFooter1 = new HeaderFooter();
                OddHeader oddHeader1 = new OddHeader();
                oddHeader1.Text = "&L&G";
                headerFooter1.Append(oddHeader1);
                worksheet1.Append(headerFooter1);
                LegacyDrawingHeaderFooter legacyDrawingHeaderFooter1 = new LegacyDrawingHeaderFooter() { Id = "rId2" };
                worksheet1.Append(legacyDrawingHeaderFooter1);
            }
                private static System.IO.Stream GetBinaryDataStream(string base64String)
            {
                return new System.IO.MemoryStream(System.Convert.FromBase64String(base64String));
            }
            
        }
    }
