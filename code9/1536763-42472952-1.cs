        [DataContract(Name = "Root", Namespace = "http://www.MyNamespace.com")]
        public class RootObject
        {
            [DataMember]
            public NestedObject NestedObject { get; set; }
        }
        [DataContract(Name = "Nested", Namespace = "http://www.MyNamespace.com")]
        public class NestedObject
        {
            string sensitiveData;
            [DataMember(IsRequired = false, EmitDefaultValue = false)]
            public string SensitiveData
            {
                get
                {
                    if (SerializationState.InCustomSerialization())
                        return null;
                    return sensitiveData;
                }
                set
                {
                    sensitiveData = value;
                }
            }
            [DataMember]
            public string PublicData { get; set; }
        }
        public static class SerializationState
        {
            [ThreadStatic]
            static bool inCustomSerialization;
            public static bool InCustomSerialization()
            {
                return inCustomSerialization;
            }
            public static IDisposable SetInCustomDeserialization(bool value)
            {
                return new PushValue<bool>(value, () => inCustomSerialization, b => inCustomSerialization = b);
            }
        }
        public struct PushValue<T> : IDisposable
        {
            Action<T> setValue;
            T oldValue;
            public PushValue(T value, Func<T> getValue, Action<T> setValue)
            {
                if (getValue == null || setValue == null)
                    throw new ArgumentNullException();
                this.setValue = setValue;
                this.oldValue = getValue();
                setValue(value);
            }
            #region IDisposable Members
            // By using a disposable struct we avoid the overhead of allocating and freeing an instance of a finalizable class.
            public void Dispose()
            {
                if (setValue != null)
                    setValue(oldValue);
            }
            #endregion
        }
    And then, when serializing, do something like:
        using (SerializationState.SetInCustomDeserialization(true))
        {
            // Serialize with data contract serializer.
        }
        
    Honestly quite ugly.
