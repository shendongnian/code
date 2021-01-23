     if (!File.Exists(path))
        {
            System.IO.File.WriteAllText(path, rxHeader + textBox8.Text);
        }
        else
        {    
            System.IO.File.AppendAllText(path, textBox8.Text);
            MessageBox.Show("Export  of " + comboBox5.Text + " table is complete!");
            textBox8.Clear();
        }
