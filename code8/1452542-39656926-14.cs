        public class IntOrDouble
        {
            int i;
            double d;
            public enum MyType
            {
                None,
                Int,
                Double
            }
            MyType myType;
            public IntOrDouble(int i)
            {
                this.i = i;
                myType = MyType.Int;
            }
            public IntOrDouble(double d)
            {
                this.d = d;
                myType = MyType.Double;
            }
            public MyType GetReturnType()
            {
                return myType;
            }
            public int GetInt()
            {
                if (!myType.Equals(MyType.Int))
                {
                    throw new Exception("wrong type");
                }
                return i;
            }
            public double GetDouble()
            {
                if (!myType.Equals(MyType.Double))
                {
                    throw new Exception("wrong type");
                }
                return d;
            }
    }
