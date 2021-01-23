    private void ligne3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
        	var ligne3 = new Ligne3();
        	//define variables/properties in Ligne3 for all values to be passed
        	//then assign them with corresponsing values
        	ligne3.Value1 = objForm2.Value1; 
        	ligne3.Value2 = objForm2.Value2; 
        	//and so on
        	ligne3.send_email();
        	ligne3.Show();
        }
