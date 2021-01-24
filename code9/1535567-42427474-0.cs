        //added optional parameter to pass combobox value after successfully record operations, or just call it
        private void RowDeleter(string cmbName = "", bool deleteFromComboxBox )
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
                NameComboBox.SelectedValuePath = ds.Tables[0].Columns["Id"].ToString();
                NameComboBox.DisplayMemberPath = ds.Tables[0].Columns["Name"].ToString();
                NameComboBox.ItemsSource = ds.Tables[0].DefaultView;
                //if record successfully inserted then remove from the 
                if (!string.IsNullOrEmpty(cmbName))
                   if (deleteFromComboxBox)
                    NameComboBox.Items.Remove(cmbName);
                   else 
                    DeleteRecord(// the selected value  );
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
 
        }
