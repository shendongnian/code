    private void ligne3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
        	var ligne3 = new Ligne3();
        	//define variables/properties in Ligne3 for all values to be passed
        	//then assign them with corresponding values
        	ligne3.Value1 = objForm2.Value1; 
        	ligne3.Value2 = objForm2.Value2; 
            ligne3.Value3 = objForm2.textBox1.Text;
	        ligne3.Value3 = objForm2.checkBox1.Value;
        	//and so on
        	ligne3.send_email();
        	ligne3.Show();
        }
