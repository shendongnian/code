    private void listBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
    {
        string text = listBox.SelectedItem.ToString();
        string tempLineValue;
        string txtFile = path.Text; //path is TextBox with file path
        string title = null;
        using (StreamReader inputReader = new StreamReader(txtFile))
        {
            while (null != (tempLineValue = inputReader.ReadLine()))
            {
                if (tempLineValue.StartsWith("*"))
                    title = tempLineValue.Substring(2, tempLineValue.Length - 4).Trim();
                else if (text == title)
                    textBox.Text += tempLineValue + Environment.NewLine;
            }
        }
    }
