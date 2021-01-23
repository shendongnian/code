    public partial class Form1 : Form
    {   
    
        private void StartApp()
        {
            LobGamma.LogInPanel.FillComboBox(LogInpanel_ComboBox, LobGamma.Connection.ObtainConnection());
        }
        private void FillComboBox(ComboBox Box, SqlConnection con)
        {
            Box.Items.Clear();
            using (con)
            {
                SqlCommand com = new SqlCommand("Select Id From UsersTable", con);
                con.Open();
                using (SqlDataReader reader = com.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Box.Items.Add(reader["Id"].ToString());
                    }
                    reader.Close();
                }
            }
            con.Close();
        }
    }
