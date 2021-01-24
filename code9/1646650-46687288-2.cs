    public string ConvertHeaderToHtml(HeaderPart header)
        {
            using (MemoryStream headerStream = new MemoryStream())
            {
                //Cathal's Docx Create
                var newDocument = Novacode.DocX.Create(headerStream);
                newDocument.Save();
                using (WordprocessingDocument headerDoc = WordprocessingDocument.Open(headerStream,true))
                {
                    var headerParagraphs = new List<OpenXmlElement>(header.Header.Elements());
                    var mainPart = headerDoc.MainDocumentPart;
                    //Cloning the List is necesery because it will throw exception for the reason
                    // that you are working with refferences of the Elements
                    mainPart.Document.Body.Append(headerParagraphs.Select(h => (OpenXmlElement)h.Clone()).ToList());
                    //Copies the Header RelationShips as Document's
                    foreach (IdPartPair parts in header.Parts)
                    {
                        //Very important second parameter of AddPart, if not set the relationship ID is being changed
                        // and the wordDocument pictures, etc. wont show
                        mainPart.AddPart(parts.OpenXmlPart,parts.RelationshipId);
                    }
                    headerDoc.MainDocumentPart.Document.Save();
                    headerDoc.Save();
                    headerDoc.Close();
                }
                return ConvertToHtml(headerStream.ToArray());
            }
        }
