      private void button1_Click(object sender, EventArgs e)
            {
                this.DialogResult = DialogResult.OK;
				HandleList();
                this.Close();
            }
			
	   private void HandleList()
	   {
		   
		    foreach (object item in this.Controls)
            {
                if(item is NoEnterTextBox) {
                valuesToReturn.Add((item as NoEnterTextBox).Text);
               }
            }
	   }	   
