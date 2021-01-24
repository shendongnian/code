    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.Data.SqlClient;
    namespace WindowsFormsApplication12
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
            private void button1_Click(object sender, EventArgs e)
            {
                //set-up object to use the web.config file
                string connectionString = WebConfigurationManager.ConnectionStrings["QSISConnection"].ConnectionString;
                //set-up connection object called 'myConnection'
                SqlConnection myConnection = new SqlConnection(connectionString);
                // open database communication
                myConnection.Open();
                //create the SQL statement
                string query = "SELECT ModuleAssessmentUser.ModuleID, ModuleAssessmentUser.AssessmentID, MarkPercentage * Assessment.AssessmentWeighting AS FinalMark FROM ModuleAssessmentUser INNER JOIN[Assessment] ON(Assessment.AssessmentID = ModuleAssessmentUser.AssessmentID) WHERE (ModuleAssessmentUser.UserID = 2)";
                //set-up SQL command and use the SQL and myConnection object
                SqlCommand myCommand = new SqlCommand(query, myConnection);
                //create a sqldatareader object that asks for dats from a table
                SqlDataAdapter adapter = new SqlDataAdapter(myCommand);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
                int markPercentage = dt.AsEnumerable().Sum(x => x.Field<int>("MarkPercentage"));
            }
        }
    }
