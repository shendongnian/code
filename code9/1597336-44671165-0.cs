    class Program
    {
        static void Main(string[] args)
        {
            Test xmlStruct;
            xmlStruct.xmlFile = "bla blaaaaaaaaaaaaaaaaaaaaaaaaaah";
            xmlStruct.number = 0;
            var size = System.Runtime.InteropServices.Marshal.SizeOf(xmlStruct);
            Console.WriteLine(size);
        }
     
    }
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]  
    struct Test
    {
       [MarshalAs(UnmanagedType.BStr)] 
       public String xmlFile;
       [MarshalAs(UnmanagedType.I4)]
       public int number; 
    }
    **Note** 
