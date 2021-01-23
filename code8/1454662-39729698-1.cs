    private void btnGenerate_Click(object sender, EventArgs e)
    {
    HashSet<int> dupTest = new HashSet<int>();
    Random rnd = new Random();
    string newLine = Environment.NewLine;
    int nums = rnd.Next(100000, 999999);
    txtNumbers.Text = nums.ToString();
    while(dupTest.Count<1000)
    {
        nums = rnd.Next(100000, 999999);
        if(!dupTest.Add(nums))
           continue;
        txtNumbers.Text =  txtNumbers.Text +newLine + nums.ToString();
    }
    }
