    using DocumentFormat.OpenXml.Packaging;
    using DocumentFormat.OpenXml.Wordprocessing;
    namespace ConsoleApp4
    {
        class Program
        {
            private static WordprocessingDocument document;
            private static System.Collections.Generic.IDictionary<System.String, OpenXmlPart> UriPartDictionary = new System.Collections.Generic.Dictionary<System.String, OpenXmlPart>();
            private static System.Collections.Generic.IDictionary<System.String, DataPart> UriNewDataPartDictionary = new System.Collections.Generic.Dictionary<System.String, DataPart>();
            static void Main(string[] args)
            {
                using (document = WordprocessingDocument.Open("<DOCX FILE PATH HERE>", true))
                {
                    BuildUriPartDictionary();
                    ChangeParts();
                }
            }
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
            private static void ChangeParts()
            {
                ChangeDocumentSettingsPart1(((DocumentSettingsPart)UriPartDictionary["/word/settings.xml"]));
            }
            private static void ChangeDocumentSettingsPart1(DocumentSettingsPart documentSettingsPart)
            {
                Settings settings1 = documentSettingsPart.Settings;
                Zoom zoom1 = settings1.GetFirstChild<Zoom>();
                zoom1.Percent = "120";
            }
        }
    }
