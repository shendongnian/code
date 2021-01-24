    using System;
    using System.Configuration;
    using System.Data;
    using MySql.Data.MySqlClient;
    
    namespace MainVoteWeb.Helpers
    {
    	public static class MyHelper
    	{
    		private static readonly string ConnectionString = ConfigurationManager.ConnectionStrings["VoteContext"].ConnectionString;
    
    		public static DataTable MyGetData(MySqlCommand command)
    		{
    			MySqlConnection connection = new MySqlConnection();
    			MySqlDataAdapter adapter = new MySqlDataAdapter();
    			DataTable data = new DataTable();
    
    			try
    			{
    				connection.ConnectionString = ConnectionString;
    				command.CommandTimeout = 500;
    				command.Connection = connection;
    				adapter.SelectCommand = command;
    
    				adapter.Fill(data);
    				return data;
    			}
    			catch (Exception e)
    			{			
    				return data;
    			}
    			finally
    			{
    				connection.Close();
    			}
    		}
    
    		public static int MyExecuteNonQuery(MySqlCommand command)
    		{
    			MySqlConnection connection = new MySqlConnection();
    			int rowsAffected = 0;
    
    			try
    			{
    				command.CommandTimeout = 500;
    				connection.ConnectionString = ConnectionString;
    				connection.Open();
    				command.Connection = connection;
    
    				rowsAffected = command.ExecuteNonQuery();
    				return rowsAffected.GetString();
    			}
    			catch (Exception e)
    			{
    				return 0;
    			}
    			finally
    			{
    				connection.Close();
    			}
    			return rowsAffected.ToString();
    		}
    
    		
    	}
    }
