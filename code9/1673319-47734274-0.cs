    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Data.SqlClient;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    
    namespace Iterator
    {
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                List<SqlParameter> parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("@hobbyName", "Coding"));
                IEnumerable<IDataRecord> dataFromDB = GetUserInfo("dbo.GetUserBasedOnHobby", parameters.ToArray());
                int totalCount = dataFromDB.Count();
                MessageBox.Show("Total count : " + totalCount.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.ToString());
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                List<SqlParameter> parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("@hobbyName", "Coding"));
                List<IDataRecord> allRecs = new List<IDataRecord>();
                foreach (IDataRecord eachRec in GetUserInfo("dbo.GetUserBasedOnHobby", parameters.ToArray()))
                {
                    allRecs.Add(eachRec);
                }
                int totalCount = allRecs.Count();
                MessageBox.Show("Total count : " + totalCount.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.ToString());
            }
        }
        private void FixNullParams(SqlParameter[] parameters)
        {
            foreach (SqlParameter p in parameters) if (p.Value == null) p.Value = DBNull.Value;
        }
        public IEnumerable<IDataRecord> GetUserInfo(string pName, SqlParameter[] sqlParams, int commandTimeout = -1)
        {
            using (SqlConnection cn = new SqlConnection("Data Source=MACHINE2;Initial Catalog=TestDB;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            using (SqlCommand cmd = cn.CreateCommand())
            {
                cmd.CommandText = pName;
                cmd.CommandType = CommandType.StoredProcedure;
                if (commandTimeout != -1) cmd.CommandTimeout = commandTimeout;
                if (sqlParams.Length > 0)
                {
                    FixNullParams(sqlParams);
                    cmd.Parameters.AddRange(sqlParams);
                }
                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        yield return (IDataRecord)dr;
                    }
                    cn.Close();
                }
            }
        }
      }
    }
