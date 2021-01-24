        //added optional parameter to pass combobox value after successfully record operations, or just call it
        private void RowDeleter(ComboBox myComboBox)
        {
            try
            {
                SqlConnection conn = new SqlConnection(dataconnection);
                SqlCommand cmd = new SqlCommand("myconn", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds, "yourtableset");
                //look at what it is
                String selectedId = (ComboBoxItem)(myComboBox.SelectedItem).Value.ToString();
                DeleteRecord(selectedId);
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
 
        }
