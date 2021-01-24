    private void BackgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
        	if (!Convert.ToBoolean(Panel1.Tag)) {
        		//Intialize panel1
        		Panel1.Tag = true;
        	}
        	if (!Convert.ToBoolean(Panel2.Tag)) {
        		//Intialize panel2
        		Panel2.Tag = true;
        	}
        	if (!Convert.ToBoolean(Panel3.Tag)) {
        		//Intialize panel3
        		Panel3.Tag = true;
        	}
        }
