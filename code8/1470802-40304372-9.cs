    public partial class DynamicParameters : SqlMapper.IDynamicParameters, SqlMapper.IParameterLookup, SqlMapper.IParameterCallbacks
        {
        public void Add(string name, object value, DbType? dbType, ParameterDirection? direction, int? size)
    
        public void Add(string name, object value = null, DbType? dbType = null, ParameterDirection? direction = null, int? size = null, byte? precision = null, byte? scale = null)
        }
