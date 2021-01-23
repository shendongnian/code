    using System;
    using System.Data;
    using System.Data.OleDb; 
    using System.Windows.Forms;
    
    namespace WindowsApplication1
    {
        public partial class Form1 : Form
        {
            string connetionString;
            OleDbConnection connection;
            OleDbDataAdapter oledbAdapter;
            OleDbCommandBuilder oledbCmdBuilder;
            DataSet ds = new DataSet();
            DataSet changes;
            int i;
            string Sql;
    
    
            public Form1()
            {
                InitializeComponent();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                connetionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Your mdb filename;";
                connection = new OleDbConnection(connetionString);
                Sql = "select * from tblUsers";
                try
                {
                    connection.Open();
                    oledbAdapter = new OleDbDataAdapter(Sql, connection);
                    oledbAdapter.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];
                }
                catch (Exception ex)
                {
                    MessageBox.Show (ex.ToString());
                }
            }
    
            private void button2_Click(object sender, EventArgs e)
            {
                try
                {
                    oledbCmdBuilder = new OleDbCommandBuilder(oledbAdapter);
                    changes = ds.GetChanges();
                    if (changes != null)
                    {
                        oledbAdapter.Update(ds.Tables[0]);
                    }
                    ds.AcceptChanges();
                    MessageBox.Show("Save changes");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }
    }
