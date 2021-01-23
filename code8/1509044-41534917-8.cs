    using System.Windows.Forms;
    using System.Data.SqlClient;
    
    namespace WindowsFormsApplication1
    {
        class Class1
        {
            public static bool RemoveFromDatabase(int id, ListBox listbox)
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
    }
