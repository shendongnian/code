        private byte[] MergePdfForms(Dictionary<string, Stream> files)
        {
            var dest = new MemoryStream();
            PdfDocument pdf = new PdfDocument(new PdfWriter(dest));
            PdfMerger merger = new PdfMerger(pdf);
            PdfOutline rootOutline = pdf.GetOutlines(false);
            PdfOutline helloWorld = rootOutline.AddOutline("Root");
            int pages = 1;
            foreach (var keyValuePair in files)
            {
                var firstSourcePdf = new PdfDocument(new PdfReader(keyValuePair.Value));
                var subPages = firstSourcePdf.GetNumberOfPages();
                merger.Merge(firstSourcePdf, 1, subPages);
                firstSourcePdf.Close();
                var link1 = helloWorld.AddOutline(keyValuePair.Key);
                link1.AddDestination(PdfExplicitDestination.CreateFit(pdf.GetPage(pages)));
                pages += subPages;
                
            }
            pdf.Close();
            return dest.ToArray();
        }
