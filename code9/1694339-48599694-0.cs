    static void Main(string[] args)
        {
            List<string> users = new List<string> { "Peter", "john", "Carl" };
            byte[] result = createPdf(users, "untitled-1.pdf");
            File.WriteAllBytes(@"result.pdf", result);
        }
        public static byte[] createPdf(List<string> users,string templateFile)
        {
            // create clone page for each user in users
            using (MemoryStream memoryStream = new MemoryStream())
            {
                PdfDocument pdfDoc = new PdfDocument(new PdfWriter(memoryStream).SetSmartMode(true));
                pdfDoc.InitializeOutlines();
                PdfDocument srcDoc;
                foreach (var u in users)
                {
                    MemoryStream m = new MemoryStream(fillForm(u,templateFile));
                    srcDoc = new PdfDocument(new PdfReader(m));
                    // copy content to the resulting PDF
                    srcDoc.CopyPagesTo(1, srcDoc.GetNumberOfPages(), pdfDoc);
                }
                pdfDoc.Close();
                return memoryStream.ToArray();
            }
        }
        public static byte[] fillForm(string user,string templateFile)
        {
            using (var memoryStream = new MemoryStream())
            {
                PdfReader reader = new PdfReader(templateFile); //Iput
                PdfWriter writer = new PdfWriter(memoryStream); //output
                PdfDocument pdfDoc = new PdfDocument(reader, writer);
                PdfAcroForm form = PdfAcroForm.GetAcroForm(pdfDoc, true);
                var fields = form.GetFormFields();
                if (fields.ContainsKey("address"))
                {
                    fields["address"].SetValue(user);
                }
                form.FlattenFields();
                pdfDoc.Close();
                byte[] b = memoryStream.ToArray();
                return b;
            }
        }
