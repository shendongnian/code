     private void button1_Click(object sender, EventArgs e)
            {
    
                DataTable dt = dataTbl.GetChanges(); //it will return the changes
                foreach (DataRow item in dt.Rows)
                {
                    if (Dialog(item.RowState) == DialogResult.OK) 
                    {
                        SqlCommandBuilder cmb = new SqlCommandBuilder(adp);
                        adp.UpdateCommand = cmb.GetUpdateCommand();
                        adp.Update(this.dataTbl);
    
                    }
                }
            }
