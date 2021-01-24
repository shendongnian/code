    namespace TypeTraits
    {
    class Operations<T>
        where T : IComparable, IFormattable, IConvertible, IComparable<T>, IEquatable<T>
    {
        // names from https://msdn.microsoft.com/en-us/library/ms182355.aspx
        public virtual T Add(T a, T b)
        {
            throw new NotImplementedException();
        }
    }
    sealed class OperationsInt32 : Operations<Int32>
    {
        public override Int32 Add(Int32 a, Int32 b)
        {
            return a.Value + b.Value;
        }
    }
    sealed class OperationsDouble : Operations<Double>
    {
        public override Double Add(Double a, Double b)
        {
            return a.Value + b.Value;
        }
    }
    }
