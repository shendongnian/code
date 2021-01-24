    private void addBtn_Click(object sender, EventArgs e)
    {
        int i = 0;
        for (; i < nums.Length; i++)
        {
            if (nums[1] == 0)
            {
                nums[1] = int.Parse(inputText.Text);
                break;
            }
        }
        MessageBox.Show(nums[i].ToString());
    }
