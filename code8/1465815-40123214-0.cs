    private void button2_Click(object sender, EventArgs e)
        {
            dataGridView2.EndEdit();
            SqlCommand com = new SqlCommand();
            com.Connection = con;
            com.Parameters.Add("@EngWord", SqlDbType.NVarChar, 256, "EngWord");
            com.Parameters.Add("@ID", SqlDbType.Int, 32, "ID");
            com.CommandText = "update Name_Corpus2 set EngWord = @EngWord where ID = @ID";
                        
            da.UpdateCommand = com;
            da.Update(dataTable);
            MessageBox.Show("Updated");
            bind(classification, language);            
        }
