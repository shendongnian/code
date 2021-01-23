        public class ClassToPass
        {
            public int num = 0;
        }
    
        class OtherClass
        {
            int Numeral = 2;
            ClassToPass classtestinside;
    
            public OtherClass()//default ctor
            {}
    
            public OtherClass(int valuereceived): this(valuereceived, null)//only int ctor
            {}
    
            public OtherClass( ClassToPass _Classtest)//classtopass ctor
            : this(0, _Classtest)
            {
            }
            public OtherClass(int valuereceived, ClassToPass _Classtest)//master ctor
                : this()
            {
                Numeral = valuereceived;
                if (_Classtest != null)
                {
                    classtestinside = _Classtest;
                    classtestinside.num = 34;
                }
            }
        }
