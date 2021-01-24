    public interface IFoo<T>
    {
        T Read();
    }
    public class Foo<T> : IFoo<T>
    {
        public Type Type { get { return typeof(T); } }
        public T Read()
        {
            Type type = typeof(T);
            byte[] buffer = ...;
            object boxedResult;
            using (MemoryStream ms = new MemoryStream(buffer))
            {
                using (BinaryReader br = new BinaryReader(ms))
                {
                    if (type == typeof(int))
                        boxedResult = br.ReadInt32();
                    else if (type == typeof(long))
                        boxedResult = br.ReadInt64();
                    else if (type == typeof(bool))
                        boxedResult = br.ReadBoolean();
                    else if (type == typeof(byte))
                        boxedResult = br.ReadByte();
                    // ...
                    // other types you want to process
                    // ...
                    else boxedResult = null;
                }
            }
            if (boxedResult != null)
                return (T)boxedResult;
            else
                throw new Exception(string.Format("{0} not supported", type.Name));
        }
    }
