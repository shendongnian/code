    Form2 secondForm;
    private void button_Clicked (object sender, EventArgs e)
    {
        if (secondForm != null)
        {
            secondForm.yourButton.Enabled = true;
            secondForm.Closing += new System.EventHandler(Form2_Closing);
        }
        // Any other code you want to handle
    }
    private void Form2_Closing (object sender, EventArgs e)
    {
        secondForm = null;
    }
