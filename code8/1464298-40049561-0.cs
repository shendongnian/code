    [Serializable]
    [KnownType(typeof(List<ErrorInfo>))]
    [KnownType(typeof(ErrorInfo))]
    public class MyCustomException : Exception
    {
        public List<ErrorInfo> ErrorInfoList { get; set; }
        public MyCustomException()
            : base()
        {
            this.ErrorInfoList = new List<ErrorInfo>();
        }
        protected MyCustomException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            foreach (SerializationEntry entry in info)
            {
                if (entry.Name == "ErrorInfoList")
                {
                    if (entry.Value == null)
                        this.ErrorInfoList = null;
                    else
                    {
                        if (entry.Value is List<ErrorInfo>)
                        {
                            // Already fully typed (BinaryFormatter and DataContractSerializer)
                            this.ErrorInfoList = (List<ErrorInfo>)entry.Value; 
                        }
                        else if (entry.Value is IEnumerable && !(entry.Value is string))
                        {
                            var enumerable = (IEnumerable)entry.Value;
                            if (!enumerable.OfType<object>().Any())
                            {
                                // Empty collection
                                this.ErrorInfoList = new List<ErrorInfo>();
                            }
                            else if (enumerable.OfType<ErrorInfo>().Any())
                            {
                                // Collection is untyped but entries are typed (DataContractJsonSerializer)
                                this.ErrorInfoList = enumerable.OfType<ErrorInfo>().ToList();
                            }
                        }
                        if (this.ErrorInfoList == null)
                        {
                            // Entry value not already deserialized into a collection (typed or untyped) of ErrorInfo instances (json.net).
                            // Let the supplied formatter converter do the conversion.
                            this.ErrorInfoList = (List<ErrorInfo>)info.GetValue("ErrorInfoList", typeof(List<ErrorInfo>));
                        }
                    }
                }
            }
        }
        [SecurityPermissionAttribute(SecurityAction.Demand, SerializationFormatter = true)]
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
            {
                throw new ArgumentNullException("info");
            }
            info.AddValue("ErrorInfoList", this.ErrorInfoList, typeof(List<ErrorInfo>));
            base.GetObjectData(info, context);
        }
    }
    [Serializable]
    [KnownType(typeof(ErrorInfo.ErrorCode))]
    public class ErrorInfo : ISerializable
    {
        public enum ErrorCode
        {
            One,
            Two
        }
        public ErrorCode Code { get; set; }
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Code", this.Code, typeof(ErrorCode));
        }
        public ErrorInfo() { }
        protected ErrorInfo(SerializationInfo info, StreamingContext context)
        {
            this.Code = (ErrorCode)Enum.Parse(typeof(ErrorCode), info.GetInt32("Code").ToString());
        }
    }
