    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Data;
    using System.Data.SqlClient;
    using System.Configuration;
    namespace DAL
    {
    public class DataAccessLayer
    {
        SqlConnection con = new 
        SqlConnection(ConfigurationSettings.AppSettings["DBCS"]);
        SqlCommand cmd;
        DataSet ds;
        SqlDataAdapter da;
        public void openConection()
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
        }
        
        public void sendonly(string SP_Name, SqlParameter[] param)
        {
            try
            {
                openConection();
                cmd = new SqlCommand(SP_Name, con);
                cmd.CommandType = CommandType.StoredProcedure;
                for (int i = 0; i < param.Length; i++)
                {
                    cmd.Parameters.Add(param[i]);
                }
                cmd.ExecuteNonQuery();
               
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                con.Close();
                cmd.Dispose();
            }
            
        }
        public DataSet getonly(string SP_Name)
        {
            try
            {
                openConection();
                cmd = new SqlCommand(SP_Name, con);
                cmd.CommandType = CommandType.StoredProcedure;
                da = new SqlDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                con.Close();
                cmd.Dispose();
                da.Dispose();
            }
            return ds;
            
        }
        public DataSet sendget(string SP_Name, SqlParameter[] param)
        {
            try
            {
                openConection();
                cmd = new SqlCommand(SP_Name, con);
                cmd.CommandType = CommandType.StoredProcedure;
                for (int i = 0; i < param.Length; i++)
                {
                    cmd.Parameters.Add(param[i]);
                }
                da = new SqlDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                con.Close();
                cmd.Dispose();
                da.Dispose();
            }
            return ds;
        }
    }
