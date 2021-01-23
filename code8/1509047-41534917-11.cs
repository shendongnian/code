    using System;
    using System.Windows.Forms;
    using System.Data.SqlClient;
    
    namespace WindowsFormsApplication1
    {
        public static class admin
        {
            public static bool RemoveSpeller(int id, ListBox listbox)
            {
    
                if (listbox.Items.Contains(id.ToString()))
                {
                    MessageBox.Show("Exists");
                    listbox.Items.Remove(id.ToString());
                    try
                    {
    
                        SqlConnection con = new SqlConnection(/*Connection string goes here*/);
    
                        con.Open();
                        SqlCommand com = new SqlCommand("DELETE FROM Speler WHERE id = '" + id + "'", con);
    
                        com.ExecuteNonQuery();
    
                        con.Close();
                        return true;
    
                    }
                    catch (SqlException)
                    {
                        MessageBox.Show("Something went wrong while removing the item");
                        return false;
    
                    }
                }
                else
                {
                    MessageBox.Show("Wasn't found!");
                    return false;
                }
    
    
            }
        }
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
            private void button1_Click(object sender, EventArgs e)
            {
    
               admin.RemoveSpeller(Convert.ToInt16(tbId.Text), yourlistboxname);
    
            }
        }
    }
