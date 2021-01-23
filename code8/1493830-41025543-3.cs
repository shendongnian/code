    public abstract class SqlHashSetBase<T> : HashSet<T>, IEnumerable<SqlDataRecord>
    {
    	protected abstract SqlDbType DbType { get; }
    
    	IEnumerator<SqlDataRecord> IEnumerable<SqlDataRecord>.GetEnumerator()
    	{
    		SqlDataRecord ret = new SqlDataRecord(new SqlMetaData("value", this.DbType));
    		foreach (T data in this)
    		{
    			ret.SetValue(0, data);
    			yield return ret;
    		}
    	}
    }
