    private List<int> numbers = new List<int>();
    private void btnAdd_Click(object sender, EventArgs e)
    {
        if(Int32.TryParse(TextBox1.Text, out int n)) {
            numbers.Add(n);
            listBox1.DataSource = null;
            listBox1.DataSource = numbers;
        } else {
            MsgBox.Show("You must enter an integer!");
        }
    }
    private void btnSort_Click(object sender, EventArgs e)
    {
        numbers.Sort();
        listBox1.DataSource = null;
        listBox1.DataSource = numbers;
    }
