    public class Factory {
        public Base<T> create<T>() {
            var typeCode = Type.GetTypeCode(typeof(T));
            switch (typeCode)
            {
                case TypeCode.Empty:
                    break;
                case TypeCode.Object:
                    break;
                case TypeCode.DBNull:
                    break;
                case TypeCode.Boolean:
                    break;
                case TypeCode.Char:
                    break;
                case TypeCode.SByte:
                    break;
                case TypeCode.Byte:
                    break;
                case TypeCode.Int16:
                    break;
                case TypeCode.UInt16:
                    break;
                case TypeCode.Int32:  // Derived1 : Base<int>
                    return new Derived1();
                    break;
                case TypeCode.UInt32:
                    break;
                case TypeCode.Int64:
                    break;
                case TypeCode.UInt64:
                    break;
                case TypeCode.Single:  // Derived2 : Base<float>
                    return new Derived2();
                    break;
                case TypeCode.Double:
                    break;
                case TypeCode.Decimal:
                    break;
                case TypeCode.DateTime:
                    break;
                case TypeCode.String:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
