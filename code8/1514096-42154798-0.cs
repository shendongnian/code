     public class BulkInsert<T> where T : class
    {
        #region Fields
        private readonly LoggingService _logger = new LoggingService(typeof(BulkInsert<T>));
        private string _connectionString;
        private string _tableName;
        private IEnumerable<string> _excludedPropertyNames;
        private int _batchSize;
        private IEnumerable<T> _data;
        private DataTable _dataTable;
        #endregion
        #region Constructor
        public BulkInsert(
            string connectionString,
            string tableName,
            IEnumerable<T> data,
            IEnumerable<string> excludedPropertyNames,
            int batchSize = 1000)
        {
            if (string.IsNullOrEmpty(connectionString)) throw new ArgumentNullException(nameof(connectionString));
            if (string.IsNullOrEmpty(tableName)) throw new ArgumentNullException(nameof(tableName));
            if (data == null) throw new ArgumentNullException(nameof(data));
            if (batchSize <= 0) throw new ArgumentOutOfRangeException(nameof(batchSize));
            _connectionString = connectionString;
            _tableName = tableName;
            _batchSize = batchSize;
            _data = data;
            _excludedPropertyNames = excludedPropertyNames == null ? new List<string>() : excludedPropertyNames;
            _dataTable = CreateCustomDataTable();
        }
        #endregion
        #region Public Methods
        public void Insert()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();
                using (var bulkCopy = new SqlBulkCopy(connection, SqlBulkCopyOptions.Default | SqlBulkCopyOptions.KeepIdentity, transaction))
                {
                    bulkCopy.BatchSize = _batchSize;
                    bulkCopy.DestinationTableName = _tableName;
                    // Let's fix tons of mapping issues by
                    // Setting the column mapping in SqlBulkCopy instance:
                    foreach (DataColumn dataColumn in _dataTable.Columns)
                    {
                        bulkCopy.ColumnMappings.Add(dataColumn.ColumnName, dataColumn.ColumnName);
                    }
                    try
                    {
                        bulkCopy.WriteToServer(_dataTable);
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex.Message);
                        transaction.Rollback();
                        connection.Close();
                    }
                }
                transaction.Commit();
            }
        }
        #endregion
        #region Private Helper Methods
        private DataTable CreateCustomDataTable()
        {
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T));
            var table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
            {
                // Just include the not excluded columns
                if (_excludedPropertyNames.All(epn => epn != prop.Name))
                {                  
                    if (prop.PropertyType.Name == "DbGeography")
                    {
                        var type = typeof(SqlGeography);
                        table.Columns.Add(prop.Name, type);
                    }
                    else
                    {
                        table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
                    }
                }
            }
            foreach (T item in _data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                {
                    // Just include the values in not excluded properties 
                    if (_excludedPropertyNames.All(epn => epn != prop.Name))
                    {
                        if (prop.PropertyType.Name == "DbGeography")
                        {                           
                            row[prop.Name] = SqlGeography.Parse(((DbGeography)prop.GetValue(item)).AsText()).MakeValid();
                        }
                        else
                        {
                            row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                        }
                    }
                }
                table.Rows.Add(row);
            }
            return table;
        }
        #endregion
    }
