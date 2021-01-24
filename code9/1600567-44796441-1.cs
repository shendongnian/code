        private static void FillPdfForm()
        {
            const string pdfTemplate = @"pdf\form.pdf";
            var newFile = @"pdf\FilledCV.PDF";
            var pdfReader = new PdfReader(pdfTemplate);
            var pdfStamper = new PdfStamper(pdfReader, new FileStream(newFile, FileMode.Create));
            var pdfFormFields = pdfStamper.AcroFields;
            string TestImage = @"pdf\test.jpg";
            PushbuttonField ad = pdfFormFields.GetNewPushbuttonFromField("08");
            ad.Layout = PushbuttonField.LAYOUT_ICON_ONLY;
            ad.ProportionalIcon = true;
            ad.Image = Image.GetInstance(TestImage);
            pdfFormFields.ReplacePushbuttonField("08", ad.Field);
            pdfFormFields.SetFieldProperty("01", "textsize", 8f, null);
            pdfFormFields.SetField("01", "Example");
            foreach (var de in pdfReader.AcroFields.Fields)
            {
                pdfFormFields.SetFieldProperty(de.Key,"setfflags",PdfFormField.FF_READ_ONLY,null);
            }
            pdfStamper.FormFlattening = false;
            pdfStamper.Close();
        }
