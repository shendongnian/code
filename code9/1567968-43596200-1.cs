            public void MergePDFs(string CADPDF, string TemplatePDF, string FinalPDF, string oldData, string newData, string jobNumber, string customer, string designer, string date)
        {
                using (Document oDoc = new Document())
                using (MemoryStream ms = new MemoryStream())
                {
                    
                    PdfSmartCopy oPDF = new PdfSmartCopy(oDoc, ms);
                    oDoc.Open();
                    // If the FinalPDF file already exists, load it's data into the PDF 1st.
                    if (File.Exists(FinalPDF))
                    {
                        byte[] bytesFinalPDF = File.ReadAllBytes(FinalPDF);
                        oPDF.AddDocument(new PdfReader(bytesFinalPDF));
                    }
                    // If it doesn't exist, the oPDF is blank at this point.
                    // Second  add the CAD and Template data to the PDF
                    // We do this by calling the GetContentToMerge method which returns the byte array of data that was created using the stamper.
                    byte[] ContentToAdd = GetContentToMerge(CADPDF, TemplatePDF, oldData, newData, jobNumber, customer, designer, date);
                    if (ContentToAdd.Length > 0)
                    {
                        oPDF.AddDocument(new PdfReader(ContentToAdd));
                    }
                    oDoc.Close();
                    // Take whatever went into oPDF object's memory stream and write it to a file with path FinalPDF
                    File.WriteAllBytes(FinalPDF, ms.ToArray());
                }
        }
