    void MoveUp(PdfStamper stamper, String fieldName, int pageNumber)
    {
        AcroFields fields = stamper.AcroFields;
        IList<AcroFields.FieldPosition> positions = fields.GetFieldPositions(fieldName);
        foreach (AcroFields.FieldPosition position in positions)
        {
            if (position.page == pageNumber)
            {
                IList<float> fieldYsBelowField = new List<float>();
                PdfDictionary pageDict = stamper.Reader.GetPageN(pageNumber);
                PdfArray annots = pageDict.GetAsArray(PdfName.ANNOTS);
                for (int i = 0; i < annots.Size; i++)
                {
                    PdfDictionary annot = annots.GetAsDict(i);
                    PdfArray rect = annot.GetAsArray(PdfName.RECT);
                    if (((PdfNumber)rect[1]).FloatValue < position.position.Bottom)
                    {
                        fieldYsBelowField.Add(((PdfNumber)rect[1]).FloatValue);
                    }
                }
                if (fieldYsBelowField.Count > 0)
                {
                    float offset = position.position.Bottom - fieldYsBelowField.Max();
                    for (int i = 0; i < annots.Size; i++)
                    {
                        PdfDictionary annot = annots.GetAsDict(i);
                        PdfArray rect = annot.GetAsArray(PdfName.RECT);
                        if (((PdfNumber)rect[1]).FloatValue < position.position.Bottom)
                        {
                            rect[1] = new PdfNumber(((PdfNumber)rect[1]).FloatValue + offset);
                            rect[3] = new PdfNumber(((PdfNumber)rect[3]).FloatValue + offset);
                        }
                    }
                }
            }
        }
    }
