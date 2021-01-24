        private void GridViewStudentsList_RowValidated(object sender, DataGridViewCellEventArgs e)
      
     {
            try
           
              {
                
                BindingSource bindingSource = (BindingSource)GridViewStudentsList.DataSource;
                DataSet changes = (DataSet)bindingSource.DataSource;
                changes.GetChanges();
                if (changes != null)
                {
                    OracleConnection con = new OracleConnection(connection);
                    con.Open();
                    OracleDataAdapter adapter = new OracleDataAdapter("select * from students_list",con );
                    GridViewStudentsList.EndEdit();
                   OracleCommandBuilder mcb = new OracleCommandBuilder(adapter);
               
                    adapter.UpdateCommand = mcb.GetUpdateCommand(true);
                  
             
                    adapter.Update(changes,"students_list");
                   changes.AcceptChanges();
                    MessageBox.Show("Cell Updated");
                   // GridViewStudentsList.EndEdit();
                    con.Close();
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }
