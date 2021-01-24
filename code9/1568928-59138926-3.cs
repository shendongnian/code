    public static Dictionary<Type, SqlDbType> typeMap = 
        new Dictionary<Type, SqlDbType>() 
    { 
        { typeof(byte), SqlDbType.TinyInt}, { typeof(sbyte), SqlDbType.TinyInt },
        { typeof(short), SqlDbType.SmallInt}, { typeof(ushort), SqlDbType.SmallInt },
        { typeof(int), SqlDbType.Int }, {typeof(uint), SqlDbType.Int },
        { typeof(long), SqlDbType.BigInt },   {typeof(ulong), SqlDbType.BigInt },               
        { typeof(float), SqlDbType.Float }, { typeof(double), SqlDbType.Float },
        { typeof(decimal), SqlDbType.Decimal }, {typeof(bool),  SqlDbType.Bit },
        { typeof(string), SqlDbType.VarChar },  {typeof(char), SqlDbType.Char },
        { typeof(Guid),  SqlDbType.UniqueIdentifier }, { typeof(DateTime), SqlDbType.DateTime}, 
        { typeof(DateTimeOffset), SqlDbType.DateTimeOffset }, { typeof(byte[]), SqlDbType.VarBinary },
        //Nullable fields
        { typeof(byte?), SqlDbType.TinyInt }, { typeof(sbyte?), SqlDbType.TinyInt },  
        { typeof(short?), SqlDbType.SmallInt}, { typeof(ushort?), SqlDbType.SmallInt }, 
        { typeof(int?), SqlDbType.Int }, { typeof(uint?), SqlDbType.Int }, 
        { typeof(long?), SqlDbType.BigInt }, { typeof(ulong?), SqlDbType.BigInt },
        { typeof(float?), SqlDbType.Float }, { typeof(double?), SqlDbType.Float },
        { typeof(decimal?), SqlDbType.Decimal}, { typeof(bool?), SqlDbType.Bit },
        { typeof(Guid?), SqlDbType.UniqueIdentifier}, { typeof(DateTime?), SqlDbType.DateTime },
        { typeof(DateTimeOffset?), SqlDbType.DateTimeOffset }
    };
