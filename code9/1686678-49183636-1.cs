        private static byte[] combineViewData(List<byte[]> viewData)
        {
            byte[] combinedViewData = null;
            using (MemoryStream ms = new MemoryStream())
            {
                using (Document document = new Document())
                {
                    using (PdfCopy copy = new PdfCopy(document, ms))
                    {
                        document.Open();
                        foreach (byte[] arr in viewData)
                        {
                            using (MemoryStream viewStream = new MemoryStream(arr))
                            {
                                using (PdfReader reader = new PdfReader(viewStream))
                                {
                                    int n = reader.NumberOfPages;
                                    for (int page = 0; page < n;)
                                    {
                                        copy.AddPage(copy.GetImportedPage(reader, ++page));
                                    }
                                }
                            }
                        }
                    }
                }
                combinedViewData = ms.ToArray();
            }
            return combinedViewData;
        }
 
