    public class LicenceNumberComparer: IComparer<string[]>
    { 
        public int Compare(string[] a, string[] b)
        {
            var len = Math.Min(a.Length, b.Length);
            for(var i = 0; i < len; i++)
            {
                var aIsNum = int.TryParse(a[i], out int aNum);
                var bIsNum = int.TryParse(b[i], out int bNum);
                if (aIsNum && bIsNum)
                {
                    if (aNum != bNum)
                    {
                        return aNum - bNum;
                    }
                }
                else
                {
                    var strCompare = String.Compare(a[i], b[i]);
                    if (strCompare != 0)
                    {
                        return strCompare;
                    }
                }
            }
            return a.Length - b.Length;
        }
    }
