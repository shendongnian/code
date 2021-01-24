    public static bool CheckIfPdfa(PdfReader reader)
        {
            if (reader.Metadata != null && reader.Metadata.Length > 0)
            {
                IXmpMeta xmpMeta = XmpMetaParser.Parse(reader.Metadata, null);
                IXmpProperty pdfaidConformance = xmpMeta.GetProperty(XmpConst.NS_PDFA_ID, "pdfaid:conformance");
                IXmpProperty pdfaidPart = xmpMeta.GetProperty(XmpConst.NS_PDFA_ID, "pdfaid:part");
                reader.Close();
                if (pdfaidConformance == null || pdfaidPart == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            return false;
        }
