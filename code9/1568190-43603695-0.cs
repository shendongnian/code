	private void btnDisplay_Click(object sender, EventArgs e)
    {
		// Delcare variables 
		int Numberofreps;
		//Get the inputs 
        if (int.TryParse(txtNumberofreps.Text, out Numberofreps) && Numberofreps > 0)
        // Note I've added a check that the Numberofreps is a positive integer.
        {
            while(Numberofreps > 0)
			{
				//Display the number of reps
				lstDisplay.Items.Add(txtPhrase.Text);
				Numberofreps--; // Note this line.
			}           
		}
		else 
		{
			MessageBox.Show("Not a Positive Integer");
		}
	}
