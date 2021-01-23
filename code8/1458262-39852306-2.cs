    //Add this line
    Boolean isClosed = false; //<--
    private void MainFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Add this
            if(isClosed == true){
                return;
            }
            DialogResult res = MessageBox.Show("Do you want to exit?"); 
            
            if (res == DialogResult.OK) {
                try {
                    SqlCommand cmd = new SqlCommand("delete from empLogin where empId=" + deleteById + "", cn);
                    cmd.ExecuteNonQuery();
                    
                    //Add this line
                    isClosed = true; //<--
                    Application.Exit();
                }
                catch (SqlException ex) {
                    MessageBox.Show(ex.Message);
                }
                finally { cn.Close(); } 
            }
    
        }
