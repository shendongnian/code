    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    
    public class DatabaseImageOperations
    {
        private string databaseServer = @".\SQLEXPRESS";
        private string defaultCatalog = "ImageData1";
        private string _ConnectionString;
        private string ConnectionString
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
        public DatabaseImageOperations()
        {
            _ConnectionString = $"Data Source={databaseServer};Initial Catalog={defaultCatalog};Integrated Security=True";
        }
        public void InsertImages(List<ImageItem> Images)
        {
            using (SqlConnection cn = new SqlConnection { ConnectionString = ConnectionString })
            {
                using (SqlCommand cmd = new SqlCommand { Connection = cn })
                {
                    cmd.CommandText = "INSERT INTO ImageData (ImageData, [Description]) " + 
                                      "VALUES  (@img, @description);SELECT CAST(scope_identity() AS int);";
    
                    cmd.Parameters.Add("@img", SqlDbType.Image);
                    cmd.Parameters.Add("@description", SqlDbType.Text);
    
                    cmd.Parameters.Add(new SqlParameter
                    {
                        ParameterName = "@new_identity",
                        SqlDbType = SqlDbType.Int,
                        Direction = ParameterDirection.Output
                    });
    
                    cn.Open();
    
                    foreach (ImageItem item in Images)
                    {
                        cmd.Parameters["@img"].Value = item.Bytes;
                        cmd.Parameters["@description"].Value = item.Description;
                        item.Id = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                }
            }
        }
    }
