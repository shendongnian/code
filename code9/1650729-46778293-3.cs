    private void addBtn_Click(object sender, EventArgs e)
    {
        int i = 0;
        for (; i < nums.Length; i++)
        {
            if (nums[i] == 0)
            {
                nums[i] = int.Parse(inputText.Text);
                break;
            }
        }
        MessageBox.Show(nums[i].ToString());
    }
