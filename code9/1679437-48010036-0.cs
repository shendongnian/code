            PdfCommon.Initialize();
            using (var doc = PdfDocument.Load(@"d:\1\Europa Service Karte.pdf"))
            {
                foreach(var page in doc.Pages)
                {
                    foreach(var obj in page.PageObjects)
                    {
                        if(!(obj is PdfImageObject))
                        {
                            return; //this is a "normal" pdf;
                        }
                    }
                }
                //there is no any page with non image objects
                //so it is a scanned PDF
            }
