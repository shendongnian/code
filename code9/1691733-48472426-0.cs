    //Author: Racil Hilan
    //You are free to modify and use this class in any project, personal or commercial,
    //as long as you include this note. The author assumes no responsibility whatsoever
    //for any damage that results from using this class, and does not guarantee in any way
    //the suitability of this class for any purpose.
    using System;
    using System.Configuration;
    using System.Data;
    using System.Data.Common;
    using System.Data.SqlClient;
    
    namespace DataLayer {
      /// <summary>Class that encapsulates a SQL Server database connection and CRUD operations.</summary>
      public class SQLServerDb : IDisposable {
        private DbConnection _con;
    
        /// <summary>Default constructor which uses the "DefaultConnection" connectionString.</summary>
        public SQLServerDb() : this("DefaultConnection") { }
    
        /// <summary>Constructor which takes the connection string name.</summary>
        /// <param name="connectionStringName"></param>
        public SQLServerDb(string connectionStringName) {
          string connectionString = ConfigurationManager.ConnectionStrings[connectionStringName].ConnectionString;
          _con = new SqlConnection(connectionString);
        }
    
        /// <summary>Executes a non-query command.</summary>
        /// <param name="command">The command to execute.</param>
        /// <returns>The count of records affected by the command.</returns>
        public int ExecuteNonQuery(DbCommand command) {
          int result = 0;
          if (command == null)
            throw new ArgumentException("Command cannot be null.");
          try {
            _con.Open();
            result = command.ExecuteNonQuery();
          }
          finally {
            _con.Close();
          }
          return result;
        }
    
        /// <summary>Executes a command that returns a single scalar value.</summary>
        /// <param name="command">The command to execute.</param>
        /// <returns>The value returned by executing the command.</returns>
        public object ExecuteScalar(DbCommand command) {
          object result = null;
          if (command == null)
            throw new ArgumentException("Command cannot be null.");
          try {
            _con.Open();
            result = command.ExecuteScalar();
          }
          finally {
            _con.Close();
          }
          return result;
        }
    
        /// <summary>Executes a command that returns a DataSet.</summary>
        /// <param name="command">The command to execute.</param>
        /// <returns>The DataSet returned by executing the ecommand.</returns>
        public DataSet ExecuteDataSet(DbCommand command) {
          DataSet ds = new DataSet();
          if (command == null)
            throw new ArgumentException("Command cannot be null.");
          try {
            DbDataAdapter ad = new SqlDataAdapter((SqlCommand)command);
            ad.Fill(ds);
          }
          finally {
            _con.Close();
          }
          return ds;
        }
    
        /// <summary>Creates a command with the given parameters.</summary>
        /// <param name="commandText">The SQL query to execute.</param>
        /// <returns>The created command.</returns>
        public DbCommand GetSqlStringCommand(string commandText) {
          return GetCommand(commandText, CommandType.Text);
        }
    
        /// <summary>Creates a command with the given parameters.</summary>
        /// <param name="commandText">The name of the stored procedure to execute.</param>
        /// <returns>The created command.</returns>
        public DbCommand GetStoredProcedureCommand(string commandText) {
          return GetCommand(commandText, CommandType.StoredProcedure);
        }
    
        /// <summary>Creates a command with the given parameters.</summary>
        /// <param name="commandText">The name of the stored procedure to execute.</param>
        /// <returns>The created command.</returns>
        private DbCommand GetCommand(string commandText, CommandType commandType) {
          DbCommand command = _con.CreateCommand();
          command.CommandType = commandType;
          command.CommandText = commandText;
          return command;
        }
    
        /// <summary>Adds an in parameter to a command.</summary>
        /// <param name="command">The SQL query to execute</param>
        /// <param name="name">The name of the parameter.</param>
        /// <param name="dbType">The type of the parameter.</param>
        /// <param name="value">The value of the parameter.</param>
        public void AddInParameter(DbCommand command, string name, DbType dbType, object value) {
          AddParameter(command, name, dbType, value, ParameterDirection.Input, 0);
        }
    
        /// <summary>Adds an out parameter to a command.</summary>
        /// <param name="command">The SQL query to execute</param>
        /// <param name="name">The name of the parameter.</param>
        /// <param name="dbType">The type of the parameter.</param>
        /// <param name="size">The maximum size, in bytes, of the data within the column.</param>
        public void AddOutParameter(DbCommand command, string name, DbType dbType, int size) {
          AddParameter(command, name, dbType, null, ParameterDirection.Output, size);
        }
    
        /// <summary>Adds a parameter to a command.</summary>
        /// <param name="command">The SQL query to execute</param>
        /// <param name="name">The name of the parameter.</param>
        /// <param name="dbType">The type of the parameter.</param>
        /// <param name="value">The value of the parameter.</param>
        /// <param name="direction">The direction for the parameter.</param>
        /// <param name="size">The maximum size, in bytes, of the data within the column.</param>
        private void AddParameter(DbCommand command, string name, DbType dbType, object value, ParameterDirection direction, int size) {
          var parameter = command.CreateParameter();
          parameter.ParameterName = name;
          parameter.DbType = dbType;
          parameter.Value = value ?? DBNull.Value;
          parameter.Direction = direction;
          if (size > 0)
            parameter.Size = size;
          command.Parameters.Add(parameter);
        }
    
        public void Dispose() {
          if (_con != null) {
            _con.Dispose();
            _con = null;
          }
        }
      }
    }
