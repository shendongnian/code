    using System;
    using System.Data.SqlClient;
    using System.Reflection;
    namespace DAL.CopyCoinDataFromOracle.CoinDataTableAdapters
    {    
        partial class spCopyCoinDataTableAdapter : System.ComponentModel.Component
        {
            public spCopyCoinDataTableAdapter(int Timeout)
            {            
                SetCommandTimeout(Timeout);
            }
            public void SetCommandTimeout(int Timeout)
            {
                foreach (var item in SelectCommand())
                {
                    item.CommandTimeout = Timeout;                
                }
            }
            private System.Data.SqlClient.SqlConnection GetConnection()
            {
                 return GetProperty("Connection") as      
                 System.Data.SqlClient.SqlConnection;
            }
            private SqlCommand[] SelectCommand()
            {
                 return GetProperty("CommandCollection") as SqlCommand[];
            }
            private Object GetProperty(String s)
            {
                 return this.GetType().GetProperty(s, BindingFlags.NonPublic | BindingFlags.GetProperty | BindingFlags.Instance).GetValue(this, null);
            }
        }
    }
    
