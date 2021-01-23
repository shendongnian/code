    using System;
    using System.Windows.Forms;
    using System.Data.SqlClient;
    
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
            public bool RemoveFromDatabase(int id)
            {
                int rowsaffected;
                try
                {
                    using (SqlConnection con = new SqlConnection(/*Connection string goes here*/))
                    {
                        using (SqlCommand com = new SqlCommand("DELETE FROM Speler WHERE id = '" + id + "'", con))
                        {
                            rowsaffected = com.ExecuteNonQuery();
                            return true;
    
                        }
                    }
                }
                catch (SqlException)
                {
                    MessageBox.Show("Something went wrong while removing the item");
                    return false;
                }
                
    
            }
            
    
            private void button1_Click(object sender, EventArgs e)
            {
                
                bool feedback = RemoveFromDatabase(Convert.ToInt16(textBox1.Text));
                if (feedback)
                {
                    //Do something
                }else
                {
                    //Do Something else
                }
                
            }
        }
    }
