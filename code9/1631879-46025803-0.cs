    public sealed class grpaComparer : IComparer<grpa>
    {
        public int Compare(grpa x, grpay)
        {
            var result = SafeNativeMethods.StrCmpLogicalW(x.folder_name, y.folder_name);
            if(result != 0)
                return result;
            return SafeNativeMethods.StrCmpLogicalW(x.file_name, y.file_name);
        }
    }
