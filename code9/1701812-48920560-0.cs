     using RasterEdge.XDoc.PDF;
     static void EditTag(string PDF) 
        {       
            PDFDocument doc = new PDFDocument(PDF);
            List<IPDFAnnot> annots = PDFAnnotHandler.GetAllAnnotations(doc);
            foreach (IPDFAnnot annot in annots)
            {
                if (annot is PDFAnnotTextBox)
                {
                    PDFAnnotTextBox obj = (PDFAnnotTextBox)annot;
                    if (obj.Content.Trim() == "Content to be searched and replaced")
                    {
                        //  get the 1st page
                        PDFPage page = (PDFPage)doc.GetPage(0);
                        //  create the annotation
                        PDFAnnotTextBox test = new PDFAnnotTextBox();
                        //Copy Properties of Original Annotation
                        test.Boundary = obj.Boundary;
                        test.LineColor = obj.LineColor;
                        test.LineStyle = obj.LineStyle;
                        test.LineWidth = obj.LineWidth;
                        test.Opacity = obj.Opacity;
                        test.TextColor = obj.TextColor;
                        test.TextFont = obj.TextFont;
                        test.FillColor = Color.Yellow;
                        test.TextFont = new System.Drawing.Font(test.TextFont.FontFamily, 6);
                        
                        //Changing the Required Subject and Content of Annotation
                        test.Content = obj.Content + "appending content";
                        
                        Console.WriteLine("Deleting Existing Annotation.");
                        PDFAnnotHandler.DeleteAnnotation(doc, obj);
                        Console.WriteLine("Deleted.");
                        Console.WriteLine("Adding new Annotation.");
                        PDFAnnotHandler.AddAnnotation(page, test);
                        Console.WriteLine("New Annotation added.");
                        //  save the PDF
                        doc.Save(PDF);
                    }
                }
            }
        }
