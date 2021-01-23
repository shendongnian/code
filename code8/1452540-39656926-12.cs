        public enum MyType
        {
            None,
            T1,
            T2
        }
        public class CompositeType<T1,T2>
        {
            T1 i;
            T2 d;
            MyType myType;
            public CompositeType(T1 i)
            {
                this.i = i;
                myType = MyType.T1;
            }
            public CompositeType(T2 d)
            {
                this.d = d;
                myType = MyType.T2;
            }
            public MyType GetReturnType()
            {
                return myType;
            }
            public T1 GetT1()
            {
                if (!myType.Equals(MyType.T1))
                {
                    throw new Exception("wrong type");
                }
                return i;
            }
            public T2 GetT2()
            {
                if (!myType.Equals(MyType.T2))
                {
                    throw new Exception("wrong type");
                }
                return d;
            }
        }
