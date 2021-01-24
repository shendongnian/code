      private void button1_Click(object sender, EventArgs e)
            {
                this.DialogResult = DialogResult.OK;
			    HandleList();
                this.Close();
            }
			
	   private void HandleList()
	   {
		   
		    foreach (Control c in this.Controls)
            {
                if(c is TextBox)
                {
                    valuesToReturn.Add(c.Text);
                }
            }
	   }	   
