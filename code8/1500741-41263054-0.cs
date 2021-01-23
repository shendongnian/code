    private void button_Click(object sender, EventArgs e)
    {
        Button button = sender as Button;
        string buttonName = button.Name; //Button does not have an ID - use Name instead
        MessageBox.Show(buttonName);
    }
