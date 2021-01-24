    public virtual void GetObjectData(SerializationInfo info, StreamingContext context) {
        SerializationFormat remotingFormat = RemotingFormat;
        bool isSingleTable = context.Context != null ? Convert.ToBoolean(context.Context, CultureInfo.InvariantCulture) : true;
        SerializeDataTable(info, context, isSingleTable, remotingFormat);
    }
