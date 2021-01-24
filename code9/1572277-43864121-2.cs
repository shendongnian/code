    public static void ChangeZoomOfLinksFixedMore(PdfReader reader, double zoom = 1)
    {
        for (int i = 1; i < reader.NumberOfPages; i++)
        {
            PdfDictionary page = reader.GetPageN(i);
            PdfArray annotationsArray = page.GetAsArray(PdfName.ANNOTS);
            if (annotationsArray == null)
                continue;
            for (int j = 0; j < annotationsArray.Size; j++)
            {
                PdfDictionary annotation = annotationsArray.GetAsDict(j);
                PdfDictionary annotationAction = annotation.GetAsDict(PdfName.A);
                if (annotationAction == null)
                    continue;
                PdfName actionType = annotationAction.GetAsName(PdfName.S);
                PdfArray d = null;
                if (PdfName.GOTO.Equals(actionType))
                    d = annotationAction.GetAsArray(PdfName.D);
                else if (PdfName.LINK.Equals(actionType))
                    d = annotation.GetAsArray(PdfName.DEST);
                if (d == null)
                    continue;
                if (d.Size < 2)
                {
                    Console.WriteLine("Page {0} {1} {2}. Invalid.", i, actionType, d);
                    continue;
                }
                float left = 0;
                float top = 0;
                PdfObject pageObject = PdfReader.GetPdfObjectRelease(d[0]);
                if (pageObject is PdfDictionary)
                {
                    PdfArray cropBox = ((PdfDictionary)pageObject).GetAsArray(PdfName.CROPBOX);
                    if (cropBox == null)
                        cropBox = ((PdfDictionary)pageObject).GetAsArray(PdfName.MEDIABOX);
                    if (cropBox != null && cropBox.Size == 4)
                    {
                        if (cropBox[0] is PdfNumber)
                            left = ((PdfNumber)cropBox[0]).FloatValue;
                        if (cropBox[3] is PdfNumber)
                            top = ((PdfNumber)cropBox[3]).FloatValue;
                    }
                }
                // for custom zoom type
                if (d.Size == 5 && PdfName.XYZ.Equals(d.GetAsName(1)))
                {
                    Console.WriteLine("Page {0} {1} XYZ; former zoom {2}.", i, actionType, d[4]);
                    d[4] = new PdfNumber(zoom);
                }
                // for Fit zoom
                else if (d.Size == 2 && PdfName.FIT.Equals(d.GetAsName(1)))
                {
                    Console.WriteLine("Page {0} {1} Fit.", i, actionType);
                    d[1] = PdfName.XYZ;
                    d.Add(new PdfNumber(left));
                    d.Add(new PdfNumber(top));
                    d.Add(new PdfNumber(zoom));
                }
                else
                {
                    Console.WriteLine("Page {0} {1} {2}. To be implemented.", i, actionType, d.GetAsName(1));
                }
            }
        }
    }
