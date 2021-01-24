    void MoveUp(PdfStamper stamper, String fieldName, String moveFieldName, int pageNumber)
    {
        AcroFields fields = stamper.AcroFields;
        IList<AcroFields.FieldPosition> positions = fields.GetFieldPositions(fieldName);
        foreach (AcroFields.FieldPosition position in positions)
        {
            if (position.page == pageNumber)
            {
                Item moveFieldItem = fields.GetFieldItem(moveFieldName);
                for (int i = 0; i < moveFieldItem.Size; i++)
                {
                    if (moveFieldItem.GetPage(i) == pageNumber)
                    {
                        PdfDictionary annot = moveFieldItem.GetWidget(i);
                        PdfArray rect = annot.GetAsArray(PdfName.RECT);
                        float offset = position.position.Bottom - ((PdfNumber)rect[1]).FloatValue;
                        rect[1] = new PdfNumber(((PdfNumber)rect[1]).FloatValue + offset);
                        rect[3] = new PdfNumber(((PdfNumber)rect[3]).FloatValue + offset);
                        break;
                    }
                }
            }
        }
    }
