            private void save_Click(object sender, EventArgs e)
            {
                DeletePerson(id); // add this
                SqlConnection cn = new SqlConnection();
                ...
            }
    
    
            public void DeletePerson(int id)
            {
                using(SqlConnection connection = new SqlConnection(credentials))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = connection;   
                    cmd.CommandText = "delete from studetail where someUniqeIdColumn = " + id;                    
                }
            }
