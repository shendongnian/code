    using Data_Layer.Repository;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using Data_Layer.Helper;
    
    namespace Data_Layer.Context
    {
        public class EmployeeContext : DbCommand, IEmployeeRepository
        {
            private bool disposed = false;
            private string dbConnection;
    
            #region Constructor:
    
            public EmployeeContext(string dbConnection)
            {
                this.dbConnection = dbConnection;
            }
    
            #endregion
    
            public IEnumerable<TEntity> List<TEntity>(string query, CommandType commandType, params SqlParameter[] parameters) where TEntity : class, new()
            {
                using (var connection = new SqlConnection(dbConnection))
                using (var command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    command.CommandType = commandType;
    
                    foreach (var parameter in parameters)
                        command.Parameters.Add(parameter);
    
                    return BuildEntity(command, new TEntity());
                }
            }
    
            #region Dispose:
    
            public void Dispose()
            {
                Dispose(true);
                GC.SuppressFinalize(true);
            }
    
            protected virtual void Dispose(bool disposing)
            {
                if (!disposed)
                    disposed = true;
            }
    
            ~EmployeeContext() { Dispose(false); }
    
            #endregion
        }
    }
