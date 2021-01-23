    static class SubstringExtensions
    {
        public static String MakeXMLCompatible(this String value, String tag = "")
        {
            Int32 valueLength = value.Length;
            Int32 currentIdx = 0;
            String tmp = value;
            while (currentIdx < valueLength)
            {
                String oldStr = tmp.Between(tag + "=\"", "\" />", currentIdx);
                String newStr = System.Security.SecurityElement.Escape(oldStr);
                if (oldStr == "")
                {
                    break;
                }
                Int32 contentAttribContentValueStart = tmp.IndexOf(tag + "=\"", currentIdx) + (tag + "=\"").Length;
                Int32 contentAttibContentValueEnd = tmp.IndexOf("\" />", contentAttribContentValueStart);
                tmp = String.Concat(tmp.Substring(0, contentAttribContentValueStart), newStr, tmp.Substring(contentAttibContentValueEnd));
                currentIdx = contentAttibContentValueEnd;
            }
            if (currentIdx == 0)
            {
                return "";
            }
            else
            {
                return tmp;
            }
        }
        public static String Between(this String value, String a, String b, Int32 StartIndex = 0, Boolean useLastIndex = false)
        {
            int posA = value.IndexOf(a, StartIndex);
            if (posA == -1)
            {
                return "";
            }
            int posB = (useLastIndex ? value.LastIndexOf(b, posA) : value.IndexOf(b, posA));
            if (posB == -1)
            {
                return "";
            }
            int adjustedPosA = posA + a.Length;
            if (adjustedPosA >= posB)
            {
                return "";
            }
            return value.Substring(adjustedPosA, posB - adjustedPosA);
        }
    }
