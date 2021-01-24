    public class SynchronizedCollection<T> : IList<T>, IList
    {
        //...
        int IList.Add(object value)
        {
            VerifyValueType(value);
 
            lock (this.sync)
            {
                this.Add((T)value);
                return this.Count - 1;
            }
        }
        
        //...
        static void VerifyValueType(object value)
        {
            if (value == null)
            {
                if (typeof(T).IsValueType)
                {
                    throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentException(SR.GetString(SR.SynchronizedCollectionWrongTypeNull)));
                }
            }
            else if (!(value is T))
            {
                throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentException(SR.GetString(SR.SynchronizedCollectionWrongType1, value.GetType().FullName)));
            }
        }
    }
