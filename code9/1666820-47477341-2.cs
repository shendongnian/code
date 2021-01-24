    private void button1_Click(object sender, EventArgs e)
    {
        DialogResult dialogResult = MessageBox.Show("Weet je het zeker?", "Lesbord 1.0", MessageBoxButtons.YesNo);
        if (dialogResult == DialogResult.Yes)
        {
            MessageBox.Show("Verstuurd");
            //hier de verstuur code
            string path = @"E:\\test.txt";
            string selectedValue = comboBox1.SelectedItem.ToString();
            string selectedValue2 = comboBox2.SelectedItem.ToString();
            string selectedValue1 = comboBox3.SelectedItem.ToString();
            try {
                File.WriteAllText(path, selectedValue + " " + selectedValue2 + " " + selectedValue1);
            } catch (Exception e) {
                MessageBox.Show("Error during file writing!");
                return;
            }
            try {
                Upload(ftpServer, userName, password, path);
            } catch (Exception e) {
                MessageBox.Show("Error during file upload!");
                return;
            }
        }
    }
