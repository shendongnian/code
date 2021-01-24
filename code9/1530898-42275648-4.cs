    public interface IExecuteQuery
    {
        int Execute();
        Task<int> ExecuteAsync( CancellationToken cancellationToken );
    }
    public abstract class SqlExecuteQuery : IExecuteQuery
    {
        private readonly DbConnection _connection;
        private readonly Lazy<DbCommand> _command;
        protected SqlExecuteQuery( DbConnection connection )
        {
            if ( connection == null )
                throw new ArgumentNullException( nameof( connection ) );
            _connection = connection;
            _command = new Lazy<DbCommand>(
                () =>
                {
                    var command = _connection.CreateCommand( );
                    PrepareCommand( command );
                    return command;
                } );
        }
        protected abstract void PrepareCommand( DbCommand command );
        protected DbCommand Command => _command.Value;
        protected virtual string GetParameterNameFromPropertyName( string propertyName )
        {
            return "@" + propertyName;
        }
        protected T GetParameterValue<T>( [CallerMemberName] string propertyName = null )
        {
            object value = Command.Parameters[ GetParameterNameFromPropertyName( propertyName ) ].Value;
            if ( value == DBNull.Value )
            {
                value = null;
            }
            return (T) value;
        }
        protected void SetParamaterValue<T>( T newValue, [CallerMemberName] string propertyName = null )
        {
            object value = newValue;
            if ( value == null )
            {
                value = DBNull.Value;
            }
            Command.Parameters[ GetParameterNameFromPropertyName( propertyName ) ].Value = value;
        }
        protected virtual void OnBeforeExecute() { }
        public int Execute()
        {
            OnBeforeExecute( );
            return Command.ExecuteNonQuery( );
        }
        public async Task<int> ExecuteAsync( CancellationToken cancellationToken )
        {
            OnBeforeExecute( );
            return await Command.ExecuteNonQueryAsync( cancellationToken );
        }
    }
    public static class DbCommandExtensions
    {
        public static DbParameter AddParameter( this DbCommand command, Action<DbParameter> configureAction )
        {
            var parameter = command.CreateParameter( );
            configureAction( parameter );
            command.Parameters.Add( parameter );
            return parameter;
        }
    }
