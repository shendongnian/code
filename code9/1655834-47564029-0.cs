    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Windows.Forms;
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
            private void Form1_Load(object sender, EventArgs e)
            {
                string connetionString = null;
                SqlConnection connection;
                SqlCommand command;
                SqlDataAdapter adapter = new SqlDataAdapter();
                DataSet ds = new DataSet();
                int i = 0;
                string sql = null;
                connetionString = "Data Source=.;Initial Catalog=DatabaseName;User ID=UserName;Password=Password";
                sql = "select au_id,au_lname from authors";
                connection = new SqlConnection(connetionString);
                try
                {
                    connection.Open();
                    command = new SqlCommand(sql, connection);
                    adapter.SelectCommand = command;
                    adapter.Fill(ds);
                    adapter.Dispose();
                    command.Dispose();
                    connection.Close();
                    comboBox1.DataSource = ds.Tables[0];
                    comboBox1.ValueMember = "au_id";
                    comboBox1.DisplayMember = "au_lname";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Can not open connection ! ");
                }
            }
            private void button1_Click(object sender, EventArgs e)
            {
                MessageBox.Show(comboBox1.Text + " " + comboBox1.SelectedValue);
            }
        }
    }
