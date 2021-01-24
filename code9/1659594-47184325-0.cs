    this.dataGridView1.DataBindingComplete += DataGridView1_DataBindingComplete1;
    this.dataGridView1.DataBindingComplete += DataGridView1_DataBindingComplete2;
    this.dataGridView1.DataBindingComplete += DataGridView1_DataBindingComplete3;
    this.dataGridView1.DataBindingComplete += DataGridView1_DataBindingComplete1;
    private void DataGridView1_DataBindingComplete1(object sender, DataGridViewBindingCompleteEventArgs e)
    {
        Console.WriteLine("First");
    }
    private void DataGridView1_DataBindingComplete2(object sender, DataGridViewBindingCompleteEventArgs e)
    {
        Console.WriteLine("Second");
    }
    private void DataGridView1_DataBindingComplete3(object sender, DataGridViewBindingCompleteEventArgs e)
    {
        Console.WriteLine("Third");
    }
