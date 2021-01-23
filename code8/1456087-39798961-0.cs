    abstract class DelegatingDbDataReader : DbDataReader
    {
    	readonly DbDataReader source;
    	public DelegatingDbDataReader(DbDataReader source)
    	{
    		this.source = source;
    	}
    	public override object this[string name] { get { return source[name]; } }
    	public override object this[int ordinal] { get { return source[ordinal]; } }
    	public override int Depth { get { return source.Depth; } }
    	public override int FieldCount { get { return source.FieldCount; } }
    	public override bool HasRows { get { return source.HasRows; } }
    	public override bool IsClosed { get { return source.IsClosed; } }
    	public override int RecordsAffected { get { return source.RecordsAffected; } }
    	public override bool GetBoolean(int ordinal) { return source.GetBoolean(ordinal); }
    	public override byte GetByte(int ordinal) { return source.GetByte(ordinal); }
    	public override long GetBytes(int ordinal, long dataOffset, byte[] buffer, int bufferOffset, int length) { return source.GetBytes(ordinal, dataOffset, buffer, bufferOffset, length); }
    	public override char GetChar(int ordinal) { return source.GetChar(ordinal); }
    	public override long GetChars(int ordinal, long dataOffset, char[] buffer, int bufferOffset, int length) { return source.GetChars(ordinal, dataOffset, buffer, bufferOffset, length); }
    	public override string GetDataTypeName(int ordinal) { return source.GetDataTypeName(ordinal); }
    	public override DateTime GetDateTime(int ordinal) { return source.GetDateTime(ordinal); }
    	public override decimal GetDecimal(int ordinal) { return source.GetDecimal(ordinal); }
    	public override double GetDouble(int ordinal) { return source.GetDouble(ordinal); }
    	public override IEnumerator GetEnumerator() { return source.GetEnumerator(); }
    	public override Type GetFieldType(int ordinal) { return source.GetFieldType(ordinal); }
    	public override float GetFloat(int ordinal) { return source.GetFloat(ordinal); }
    	public override Guid GetGuid(int ordinal) { return source.GetGuid(ordinal); }
    	public override short GetInt16(int ordinal) { return source.GetInt16(ordinal); }
    	public override int GetInt32(int ordinal) { return source.GetInt32(ordinal); }
    	public override long GetInt64(int ordinal) { return source.GetInt64(ordinal); }
    	public override string GetName(int ordinal) { return source.GetName(ordinal); }
    	public override int GetOrdinal(string name) { return source.GetOrdinal(name); }
    	public override string GetString(int ordinal) { return source.GetString(ordinal); }
    	public override object GetValue(int ordinal) { return source.GetValue(ordinal); }
    	public override int GetValues(object[] values) { return source.GetValues(values); }
    	public override bool IsDBNull(int ordinal) { return source.IsDBNull(ordinal); }
    	public override bool NextResult() { return source.NextResult(); }
    	public override bool Read() { return source.Read(); }
    	public override void Close() { source.Close(); }
    	public override T GetFieldValue<T>(int ordinal) { return source.GetFieldValue<T>(ordinal); }
    	public override Task<T> GetFieldValueAsync<T>(int ordinal, CancellationToken cancellationToken) { return source.GetFieldValueAsync<T>(ordinal, cancellationToken); }
    	public override Type GetProviderSpecificFieldType(int ordinal) { return source.GetProviderSpecificFieldType(ordinal); }
    	public override object GetProviderSpecificValue(int ordinal) { return source.GetProviderSpecificValue(ordinal); }
    	public override int GetProviderSpecificValues(object[] values) { return source.GetProviderSpecificValues(values); }
    	public override DataTable GetSchemaTable() { return source.GetSchemaTable(); }
    	public override Stream GetStream(int ordinal) { return source.GetStream(ordinal); }
    	public override TextReader GetTextReader(int ordinal) { return source.GetTextReader(ordinal); }
    	public override Task<bool> IsDBNullAsync(int ordinal, CancellationToken cancellationToken) { return source.IsDBNullAsync(ordinal, cancellationToken); }
    	public override Task<bool> ReadAsync(CancellationToken cancellationToken) { return source.ReadAsync(cancellationToken); }
    	public override int VisibleFieldCount { get { return source.VisibleFieldCount; } }
    }
