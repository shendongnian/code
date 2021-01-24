    public class UserSearch 
    {
        public DataTable GetUserData(string UserLookupTextBox, string SearchByComboBox)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            using (DataTable dt = new DataTable())
            if (SearchByComboBox == "Last Name")
            {
                using (SqlCommand cmd = new SqlCommand("Select [LastName], [FirstName], [EmailAddress] from [DbUser] where (LastName=@Lookup)", con))
                {
                    cmd.Parameters.Add("@Lookup", SqlDbType.VarChar).Value = UserLookupTextBox.Trim();
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                        return dt;
                    }
                }
            }
            else
            {
            ........
            }
        }
    }
}
