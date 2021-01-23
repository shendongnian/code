    private void radioButton1_Checked(object sender, EventArgs e)
    {
        string radioButtonContent = ((RadioButton)sender).Text;
        string savePath = @"C:\sent.txt"; // or wherever
    
        File.WriteAllText(savePath, radioButtonContent);
    }
