    class OtherClass
     {
        int Numeral = 2;
        ClassToPass classtestinside;
        public OtherClass()//default ctor
        {}
        public OtherClass(int valuereceived = 0, ClassToPass _classtest = null)//master ctor
         : this()
        {
            Numeral = valuereceived;
            if(_classtest !=null)
            {               
                classtestinside = _classtest;
                classtestinside.num = 34;
            }
        }
