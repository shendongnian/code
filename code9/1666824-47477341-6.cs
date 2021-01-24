    private void button1_Click(object sender, EventArgs e)
    {
        DialogResult dialogResult = MessageBox.Show("Weet je het zeker?", "Lesbord 1.0", MessageBoxButtons.YesNo);
        if (dialogResult == DialogResult.Yes)
        {
            MessageBox.Show("Verstuurd");
            //hier de verstuur code
            string selectedValue = comboBox1.SelectedItem.ToString();
            string selectedValue2 = comboBox2.SelectedItem.ToString();
            string selectedValue1 = comboBox3.SelectedItem.ToString();
            File.WriteAllText(@"E:\test.txt", selectedValue + " " + selectedValue2 + " " + selectedValue1);
            Upload("ftp://www.myserver.com/", "myuser", "mypass", @"E:\test.txt");
        }
    }
