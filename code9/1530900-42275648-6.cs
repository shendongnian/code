    public class SqlInsertInformationQuery : SqlExecuteQuery, IInsertInformationQuery
    {
        public SqlInsertInformationQuery( DbConnection connection ) : base( connection )
        {
        }
        protected override void OnBeforeExecute()
        {
            UserCode = App_Common._USER_CODE; // this should be injected
        }
        protected override void PrepareCommand( DbCommand command )
        {
            command.CommandText =
                @"INSERT INTO do_information ( die_class_code, subinventory_code, contact_code, company_code, corg_code, created_on, created_by ) " +
                @"VALUES ( @CodeId, @SubInventoryCode, @ContactCode, @CompanyCode, @CorgCode, GETDATE(), @UserCode )";
            command.AddParameter( p =>
            {
                p.ParameterName = "@CodeId";
                p.DbType = System.Data.DbType.String;
                p.Direction = System.Data.ParameterDirection.Input;
            } );
            command.AddParameter( p =>
            {
                p.ParameterName = "@SubInventoryCode";
                p.DbType = System.Data.DbType.String;
                p.Direction = System.Data.ParameterDirection.Input;
            } );
            command.AddParameter( p =>
            {
                p.ParameterName = "@ContactCode";
                p.DbType = System.Data.DbType.String;
                p.Direction = System.Data.ParameterDirection.Input;
            } );
            command.AddParameter( p =>
            {
                p.ParameterName = "@CompanyCode";
                p.DbType = System.Data.DbType.String;
                p.Direction = System.Data.ParameterDirection.Input;
            } );
            command.AddParameter( p =>
            {
                p.ParameterName = "@CorgCode";
                p.DbType = System.Data.DbType.String;
                p.Direction = System.Data.ParameterDirection.Input;
            } );
            command.AddParameter( p =>
            {
                p.ParameterName = "@UserCode";
                p.DbType = System.Data.DbType.String;
                p.Direction = System.Data.ParameterDirection.Input;
            } );
        }
        public string CodeId
        {
            get => GetParameterValue<string>( );
            set => SetParamaterValue( value );
        }
        public string SubInventoryCode
        {
            get => GetParameterValue<string>( );
            set => SetParamaterValue( value );
        }
        public string ContactCode
        {
            get => GetParameterValue<string>( );
            set => SetParamaterValue( value );
        }
        public string CompanyCode
        {
            get => GetParameterValue<string>( );
            set => SetParamaterValue( value );
        }
        public string CorgCode
        {
            get => GetParameterValue<string>( );
            set => SetParamaterValue( value );
        }
        public string UserCode
        {
            get => GetParameterValue<string>( );
            private set => SetParamaterValue( value );
        }
    }
