            public byte[] GetContentToMerge(string CADPDF, string TemplatePDF, string oldData, string newData, string jobNumber, string customer, string designer, string date)
        {
            
            using (MemoryStream ms = new MemoryStream())
            {
                PdfReader reader = new PdfReader(TemplatePDF);
                PdfReader reader2 = new PdfReader(CADPDF);
                // Use a Memory stream instead of a filestream 
                PdfStamper stamper = new PdfStamper(reader, ms);
                //PSModel psModel = powerSHAPE.ActiveModel;
                try
                {
                    AcroFields fields = stamper.AcroFields;
                    fields.SetField("oldDataField", oldData);
                    fields.SetField("newDataField", newData);
                    fields.SetField("jobNumberField", jobNumber);
                    fields.SetField("customerField", customer);
                    fields.SetField("dateField", date);
                    fields.SetField("designerField", designer);
                    stamper.FormFlattening = false;
                    PdfImportedPage page = stamper.GetImportedPage(reader2, 1);
                    PdfContentByte cb;
                    cb = stamper.GetOverContent(1);
                    cb.AddTemplate(page, 0, -1f, 1f, 0, 0, reader.GetPageSizeWithRotation(1).Height);
                    stamper.Close();
                    reader.Close();
                    reader2.Close();
                    // The content you wanted to create is in a memory stream. 
                    // It can bee appended to a PDF as a byte[] 
                    byte[] ContentToAppend = ms.ToArray();
                    return ContentToAppend;
                    
                }
                catch
                {
                    System.Windows.MessageBox.Show("Unable to merge drawing with template!");                    
                }
                stamper.Close();
            }
            // If we made it here, something went wrong.
            return new byte[0];
        }
