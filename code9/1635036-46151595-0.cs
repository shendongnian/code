    private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        int sum = 0; // Add a variable to capture the sum
        listBox1.Items.Clear();
        listBox2.Items.Clear();
        textBox1.Clear();
        foreach (string s in checkedListBox1.CheckedItems)
        listBox1.Items.Add(s);
        foreach (int i in checkedListBox1.CheckedIndices)
        {
            if (i == 0)
            {
                listBox2.Items.Add(300);
                sum += 300; // Add the value to sum
            }
            if (i == 1)
            {
                listBox2.Items.Add(100);
                sum += 100; // Add the value to sum
            }
            if (i == 2)
            {
                listBox2.Items.Add(200);
                sum += 200; // Add the value to sum
            }
        }
  
        // Finally, show the sum in text box
        myTextBox.Text = sum.ToString();
    }
