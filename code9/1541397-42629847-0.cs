    public unsafe struct avGostParam
    {
        public int mode;
        public fixed char fs[16];
        public fixed char flist[128];
        public fixed char ival[8];
        public fixed char ctx[8];
        public string Fs
        {
            get
            {
                fixed(char* ptr=fs)
                {
                    return GetString(ptr, 16);
                }
            }
            set
            {                
                fixed(char* ptr=fs)
                {
                    SetString(ptr, 16, value);
                }
            }
        }
        private static string GetString(char* ptr, int length)
        {
            char[] result=new char[length];
            for(int i=0; i<length; i++)
            {
                result[i]=ptr[i];
            }
            return new string(result);
        }
        private static void SetString(char* ptr, int length, string value)
        {
            if(value.Length<length)
            {
                value=value.PadRight(length);
            }
            char[] items=value.ToCharArray();
            for(int i=0; i<length; i++)
            {
                ptr[i]=items[i];
            }            
        }
    }
    unsafe class Program
    {
        static void Main(string[] args)
        {
            var av=new avGostParam();
            av.Fs="ABCDEF";
            char* ptr=av.fs;
            for(int i=0; i<16; i++)
            {
                Console.Write(av.fs[i]);
            }
        }
    }
