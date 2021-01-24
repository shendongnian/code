            public string DoFormat(string num)
        {
            int pt = num.IndexOf(".");
            if (pt > 0)
            {
                return string.Format("{0:#,##0}", num.Substring(0, pt)) + num.Substring(pt, num.Length - pt);
            }
            else
            {
                return string.Format("{0:#,##0}", num);
            }
        }
