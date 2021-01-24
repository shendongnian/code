    [TypeConverter(typeof(CrazyClassTypeConverter))]
    public class CrazyClass
    {
        public char[] Charray { get; }
        public CrazyClass(char[] charray)
        {
            Charray = charray;
        }
    }
