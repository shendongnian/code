`
    public static class DiffEngine
    {
        private static Regex r = new Regex(@"(?<=[\s])", RegexOptions.Compiled);
        public static string Process(ref string TextA, ref string TextB)
        {
            var A = r.Split(TextA);
            var B = r.Split(TextB);
            var max = Math.Max(A.Count(), B.Count());
            var sbDel = new StringBuilder("<del>");
            var sbIns = new StringBuilder("<ins>");
            var sbOutput = new StringBuilder();
            var aCurr = string.Empty;
            var bCurr = string.Empty;
            var aNext = string.Empty;
            var bNext = string.Empty;
            for (int i = 0; i < max; i++)
            {
                aCurr = (i > A.Count() - 1) ? string.Empty : A[i];
                bCurr = (i > B.Count() - 1) ? string.Empty : B[i];
                aNext = (i > A.Count() - 2) ? string.Empty : A[i + 1];
                bNext = (i > B.Count() - 2) ? string.Empty : B[i + 1];
                if (aCurr == bCurr)
                {
                    sbOutput.Append(aCurr);
                }
                else
                {
                    if (aNext != bNext)
                    {
                        sbDel.Append(aCurr);
                        sbIns.Append(bCurr);
                    }
                    else
                    {
                        sbDel.Append(aCurr);
                        sbIns.Append(bCurr);
                        sbOutput
                            .Append(sbDel.ToString())
                            .Append("</del>")
                            .Append(sbIns.ToString())
                            .Append("</ins>");
                        sbDel.Clear().Append("<del>");
                        sbIns.Clear().Append("<ins>");
                    }
                }
            }
            A = null;
            B = null;
            sbDel = null;
            sbIns = null;
            return sbOutput.ToString();
        }
    }
`
