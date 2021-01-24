        public static byte[] ManipulatePdf(string src, string dest)
        {
            var ms = new MemoryStream();
            Document document = new Document();
            PdfCopy copy = new PdfSmartCopy(document, ms);
            copy.SetMergeFields();
            document.Open();
            List<PdfReader> readers = new List<PdfReader>();
            for (int i = 0; i < 2;)
            {
                PdfReader reader = new PdfReader(RenameFields(src, ++i));
                readers.Add(reader);
                copy.AddDocument(reader);
            }
            document.Close();
            foreach (var reader in readers)
            {
                reader.Close();
            }
            return ms.ToArray();
        }
        public static byte[] RenameFields(String src, int i)
        {
            MemoryStream baos = new MemoryStream();
            PdfReader reader = new PdfReader(src);
            PdfStamper stamper = new PdfStamper(reader, baos);
            AcroFields form = stamper.AcroFields;
            var keys = new HashSet<string>(form.Fields.Keys);
            foreach (var key in keys)
            {
                form.RenameField(key, string.Format("{0}_{1}", key, i));
            }
            stamper.Close();
            reader.Close();
            return baos.ToArray();
        }
