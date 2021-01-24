     public static byte[] concatAndAddContent(List<byte[]> pdfByteContent, List<MailComm> localList)
        {
            using (var ms = new MemoryStream())
            {
                using (var doc = new Document())
                {
                    using (var copy = new PdfSmartCopy(doc, ms))
                    {
                        doc.Open();
                        //add checklist at the start
                        using (var db = new StudyContext())
                        {
                            var contentId = localList[0].ContentID;
                            var temp = db.MailContentTypes.Where(x => x.ContentId == contentId).ToList();
                            if (!temp[0].Code.Equals("LAB"))
                            {
                                pdfByteContent.Insert(0, CheckListCreation.createCheckBox(localList));
                            }
                        }
                        //Loop through each byte array
                        foreach (var p in pdfByteContent)
                        {
                            //Create a PdfReader bound to that byte array
                            using (var reader = new PdfReader(p))
                            {
                                //Add the entire document instead of page-by-page
                                copy.AddDocument(reader);
                            }
                        }
                        doc.Close();
                    }
                }
                //Return just before disposing
                return ms.ToArray();
            }
        }
