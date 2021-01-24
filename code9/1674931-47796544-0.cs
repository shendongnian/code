    private void btnInsert_Click(object sender, EventArgs e)
    {
    	if (!string.IsNullOrEmpty(txtInsert.Text))
    	{
    		if (lstIntegers.Items.Contains(txtInsert.Text))
    		{
    			MessageBox.Show("Number already exists in list", "error", MessageBoxButtons.OK);
    			txtInsert.Text = string.Empty;
    			txtInsert.Focus();
    			return;
    		}
    		else
    		{
    			var x = Convert.ToInt32(txtInsert.Text);
    			if (Enumerable.Range(1,100).Contains(x))
    			{
    				lstIntegers.Items.Add(txtInsert.Text);
    				txtInsert.Clear();
    				txtInsert.Focus();
    				bubbleSort();
    			}
    			else
    			{
    				MessageBox.Show("Please input value between 1-100", "error", MessageBoxButtons.OK);
    				txtInsert.Text = string.Empty;
    				txtInsert.Focus();
    				return;
    			}
    		}
    
    	}
    	else
    	{
    		MessageBox.Show("Please input value between 1-100", "error", MessageBoxButtons.OK);
    		txtInsert.Text = string.Empty;
    		return;
    	}
    	
    	if (lstIntegers.Items.Count == 30)
    	{
    		MessageBox.Show("Maximum number of entries exceeded", "error", MessageBoxButtons.OK);
    		//button enabled was false however couldn't then add another 
    		btnInsert.Enabled = true;
    	}
    }	
