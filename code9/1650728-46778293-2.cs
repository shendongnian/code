    private List<int> nums = new List<int>();
    private void addBtn_Click(object sender, EventArgs e)
    {
        int number;
        if (int.TryParse(inputText.Text, out number))
        {
            nums.Add(number);
            MessageBox.Show(number.ToString());
        }
        else
        {
            MessageBox.Show(inputText.Text + " isn't a number, smart guy.");
        }
    }
