    public class SomeEnum
    {
        public int Name;
        public int Surname;
        private SomeEnum(int name, int surname)
        {
            Name = name;
            Surname = surname;
        }
        public static SomeEnum EnumA => new SomeEnum(1, 2);
        public static SomeEnum EnumB => new SomeEnum(50, 60);
        
    }
