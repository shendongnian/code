                enDef = new EnvelopeDefinition();
                doc = new Document();
                doc.DocumentBase64 = System.Convert.ToBase64String(System.IO.File.ReadAllBytes(filename));
                doc.Name = DocName;
                doc.DocumentId = "1"; // increment this
                enDef.Documents = new List<Document>();
                enDef.Documents.Add(doc);
