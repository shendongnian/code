    public class CriticalClass
    {
        public void SafeCode() { }
        [SecurityCritical]
        public void CriticalCode() { }
        [SecuritySafeCritical]
        public void SafeEntryForCriticalCode() => CriticalCode();
    }
    [Serializable]
    public class SerializableCriticalClass : CriticalClass, ISerializable
    {
        public SerializableCriticalClass() { }
        private SerializableCriticalClass(SerializationInfo info, StreamingContext context) { }
        [SecurityCritical]
        public void GetObjectData(SerializationInfo info, StreamingContext context) { }
    }
