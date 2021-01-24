    private void CreateCustomerButton_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(textboxFileName.Text))
        {
            MessageBox.Show("Please enter filename and try again.");
        }
    
        string destFolder = Application.ExecutablePath;
        string destination = Path.Combine(destFolder, textboxFileName.Text);
        StreamWriter File = new StreamWriter(destination);
        File.Write("Hi");
        File.Close();
    }
