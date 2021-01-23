    class Libary: ILibary
    {
        public short Methode1 (ushort FlibHndl, [Out, MarshalAs(UnmanagedType.LPStruct)] RealLibary.Struct1 a)
        {
            return RealLibary.Methode1(FlibHndl, a);
        }
    }
