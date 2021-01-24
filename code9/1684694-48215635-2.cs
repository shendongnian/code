    public class MsiInvoke
        {
            //Oops MSIHandles are not IntPtrs. 
    
            [DllImport("msi", CharSet = CharSet.Auto)]
            public static extern int MsiOpenDatabase(string filename, int persist, out IntPtr dbhandle);
            public const int MSIDBOPEN_DIRECT = 2;
            public const int MSIDBOPEN_TRANSACT = 1;
