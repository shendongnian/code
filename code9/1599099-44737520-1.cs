    using Microsoft.SqlServer.Management.Smo;
    using System;
    using System.Data;
    using System.Data.Sql;
    using System.Data.SqlClient;
    using System.Threading.Tasks;
    
    namespace StackOverFlow
    {
        public class Operations
        {
            string mExceptionMessage;
            public string ExceptionMessage { get { return mExceptionMessage; } }
            public bool HasException { get; set; }
    
            bool _databaseExists = false;
    
            bool mFoundServerInstanceName;
            public bool FoundServerInstanceName { get { return mFoundServerInstanceName; } }
    
            static string databaseServer;
            static string masterDefaultCatalog = "Master";
            string _masterConnectionString = $"Data Source={databaseServer};Initial Catalog={masterDefaultCatalog};Integrated Security=True";
            string MasterConnectionString
            {
                get
                {
                    return _masterConnectionString;
                }
                set
                {
                    _masterConnectionString = value;
                }
            }
    
            static string DefaultCatalog = "MyDb";
            string _ConnectionString = $"Data Source={databaseServer};Initial Catalog={DefaultCatalog};Integrated Security=True";
            string ConnectionString
            {
                get
                {
                    return _ConnectionString;
                }
                set
                {
                    _ConnectionString = value;
                }
            }
            public static async Task<Operations> Create()
            {
                var ops = new Operations();
                await ops.Initialize();
                return ops;
            }
            async Task<bool> Initialize()
            {
                return await GetDefaultInstanceAsync();
            }
            public async Task<bool> GetDefaultInstanceAsync()
            {
                var serverInstanceTable = new DataTable();
                try
                {
                    await Task.Run(() => { serverInstanceTable = SmoApplication.EnumAvailableSqlServers(true); });
                    if (serverInstanceTable != null)
                    {
                        databaseServer = serverInstanceTable.Rows[0].Field<string>("name");
                        mFoundServerInstanceName = true;
                    }
                    else
                    {
                        mFoundServerInstanceName = false;
                    }
    
                    return true;
    
                }
                catch (Exception ex)
                {
                    mExceptionMessage = ex.Message;
                    HasException = true;
                    return false;
                }
    
            }
            /// <summary>
            /// Determine if the database exists
            /// </summary>
            /// <returns></returns>
            public bool CheckDatabase()
            {
    
                try
                {
                    using (SqlConnection conn = new SqlConnection() { ConnectionString = MasterConnectionString })
                    {
                        using (SqlCommand cmd = new SqlCommand($"IF EXISTS (SELECT name FROM sys.databases WHERE name = '{DefaultCatalog}') SELECT 1 ELSE SELECT 0", conn))
                        {
                            conn.Open();
                            int value = (int)cmd.ExecuteScalar();
                            conn.Close();
    
                            if (value != 1)
                            {
                                CreateDatabase();
                                _databaseExists = true;
                            }
                            else
                            {
                                _databaseExists = true;
                            }
    
                        }
                    }
                }
                catch (Exception ex)
                {
                    mExceptionMessage = ex.Message;
                    _databaseExists = false;
                    HasException = true;
                }
    
                return _databaseExists;
    
            }
            /// <summary>
            /// create the database and two tables
            /// </summary>
            /// <returns></returns>
            bool CreateDatabase()
            {
                string tableCreateScript = $@"
                USE [{DefaultCatalog}]
                CREATE TABLE [dbo].[Article](
    	            [ItemName] [nvarchar](50) NOT NULL,
    	            [Barcode] [nvarchar](50) NOT NULL,
    	            [Price] [money] NOT NULL,
                 CONSTRAINT [PK_Article] PRIMARY KEY CLUSTERED 
                (
    	            [Barcode] ASC
                )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
                ) ON [PRIMARY];
                CREATE TABLE [dbo].[Worker](
    	            [FirstName] [nvarchar](50) NOT NULL,
    	            [Password] [nvarchar](50) NOT NULL,
    	            [LastName] [nvarchar](50) NOT NULL,
                PRIMARY KEY CLUSTERED 
                (
    	            [Password] ASC
                )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
                ) ON [PRIMARY];";
    
                using (SqlConnection conn = new SqlConnection() { ConnectionString = MasterConnectionString })
                {
                    try
                    {
                        using (SqlCommand comm = new SqlCommand($"CREATE DATABASE [{DefaultCatalog}];", conn))
                        {
                            conn.Open();
    
                            comm.ExecuteNonQuery();
    
                            comm.CommandText = tableCreateScript;
                            comm.ExecuteNonQuery();
    
                            return true;
    
                        }
                    }
                    catch (Exception ex)
                    {
                        mExceptionMessage = ex.Message;
                        HasException = true;
                        return false;
                    }
    
                }
    
            }
        }
    }
