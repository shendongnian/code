        public int IntSum(CompositeType<int,double> x, CompositeType<int, string> y)
        {
            int xint;
            int yint;
            switch (x.GetReturnType())
            {
                case MyType.None:
                    throw new Exception("wrong type");
                case MyType.T1:
                    xint = x.GetT1();
                    break;
                case MyType.T2:
                    xint = MyConvertToInteger(x.GetT2());
                    break;
                default:
                    throw new Exception("wrong type");
            }
            switch (y.GetReturnType())
            {
                case MyType.None:
                    throw new Exception("wrong type");
                case MyType.T1:
                    yint = y.GetT1();
                    break;
                case MyType.T2:
                    yint = MyConvertToInteger(y.GetT2());
                    break;
                default:
                    throw new Exception("wrong type");
            }
            return xint + yint;
        }
