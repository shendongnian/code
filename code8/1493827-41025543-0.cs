    public class SqlHashSetBase<T> : HashSet<T>, IEnumerable<SqlDataRecord>
    {
    	protected abstract SqlDbType DbType { get; }
    
    	public IEnumerator<SqlDataRecord> GetEnumerator() 
    	{
    		SqlDataRecord ret = new SqlDataRecord(new SqlMetaData("value", this.DbType));       
    		foreach (var data in this)
    		{
    			ret.SetValue(0, data);
    			yield return ret;
    		}
    	}
    }
