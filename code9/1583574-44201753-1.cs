    public class Lazy<T>
    {
 
        #region Inner classes
        /// <summary>
        /// wrapper class to box the initialized value, this is mainly created to avoid boxing/unboxing the value each time the value is called in case T is 
        /// a value type
        /// </summary>
        [Serializable]
        class Boxed
        {
            internal Boxed(T value)
            {
                m_value = value;
            }
            internal T m_value;
        }
