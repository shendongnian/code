    class TagFilteringExtractionStrategy : LocationTextExtractionStrategy
    {
        FieldInfo MarkedContentInfosField = typeof(TextRenderInfo).GetField("markedContentInfos", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
        FieldInfo MarkedContentInfoTagField = typeof(MarkedContentInfo).GetField("tag", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
        PdfName EMBEDDED_DOCUMENT = new PdfName("EmbeddedDocument");
        public override void RenderText(TextRenderInfo renderInfo)
        {
            IList<MarkedContentInfo> markedContentInfos = (IList<MarkedContentInfo>)MarkedContentInfosField.GetValue(renderInfo);
            if (markedContentInfos != null && markedContentInfos.Count > 0)
            {
                foreach (MarkedContentInfo info in markedContentInfos)
                {
                    if (EMBEDDED_DOCUMENT.Equals(MarkedContentInfoTagField.GetValue(info)))
                        return;
                }
            }
            
            base.RenderText(renderInfo);
        }
    }
