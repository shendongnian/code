    static class OleDbTypeMap
    {
        private static readonly Dictionary<Type,OleDbType> TypeMap = new Dictionary<Type, OleDbType> {
            {typeof(string), OleDbType.VarChar },
            {typeof(long), OleDbType.BigInt },
            {typeof(byte[]), OleDbType.Binary },
            {typeof(bool), OleDbType.Boolean },
            {typeof(decimal), OleDbType.Decimal },
            {typeof(DateTime), OleDbType.Date },
            {typeof(TimeSpan), OleDbType.DBTime },
            {typeof(double), OleDbType.Double },
            {typeof(Exception),OleDbType.Error },
            {typeof(Guid), OleDbType.Guid },
            {typeof(int), OleDbType.Integer },
            {typeof(float), OleDbType.Single },
            {typeof(short), OleDbType.SmallInt },
            {typeof(sbyte), OleDbType.TinyInt },
            {typeof(ulong), OleDbType.UnsignedBigInt },
            {typeof(uint), OleDbType.UnsignedInt },
            {typeof(ushort), OleDbType.UnsignedSmallInt },
            {typeof(byte), OleDbType.UnsignedTinyInt }
        };
        public static OleDbType GetType(Type type) => TypeMap[type];
    }
