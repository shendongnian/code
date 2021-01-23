        public int CompositeConversion<T>(CompositeType<int, T> x)
        {
            switch (x.GetReturnType())
            {
                case MyType.None:
                    throw new Exception("wrong type");
                case MyType.T1:
                    return x.GetT1();
                case MyType.T2:
                    if (typeof(T) == typeof(double))
                    {
                        return MyConvertToInteger((double)x.GetValue());
                    }
                    if (typeof(T) == typeof(string))
                    {
                        return MyConvertToInteger((string)x.GetValue());
                    }
                    throw new Exception("wrong type");
                default:
                    throw new Exception("wrong type");
            }
        }
        public int IntSum(CompositeType<int,double> x, CompositeType<int, string> y)
        {
            return CompositeConversion(x) + CompositeConversion(y);
        }
