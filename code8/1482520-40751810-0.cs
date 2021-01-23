       public interface IGetterSetter
        {
            Type DataType { get; }
            string Name { get; }
            MemberInfo UnderlyingMember { get; }
            bool CanRead { get; }
            bool CanWrite { get; }
    
            object GetValue(object obj);
            void SetValue(object obj, object value);
    
        }
