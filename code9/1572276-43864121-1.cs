    public static void ChangeZoomOfLinksFixed(PdfReader reader, double zoom = 1)
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
                    d.Add(new PdfNumber(0));
                    d.Add(new PdfNumber(0));
                    d.Add(new PdfNumber(zoom));
                }
                else if (d.Size > 1)
                {
                    Console.WriteLine("Page {0} {1} {2}. To be implemented.", i, actionType, d.GetAsName(1));
                }
                else
                {
                    Console.WriteLine("Page {0} {1} {2}. Invalid.", i, actionType, d);
                }
            }
        }
    }
