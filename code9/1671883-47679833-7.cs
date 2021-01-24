    BindingListView<Example> blv = this.dataGridView1.DataSource as BindingListView<Example>;
    List<Example> examples = examples.DataSource as List<Example>;
    Console.WriteLine("From BindingListView:");
    for (int i = 0; i < examples.Count; i++)
    {
        Example ex = examples[i];
        Console.WriteLine($"{ex.Foo} {ex.Bar}");
    }
    Console.WriteLine("\nFrom DataGridView:");
    for (int i = 0; i < this.dataGridView1.Rows.Count; i++)
    {
        DataGridViewRow row = this.dataGridView1.Rows[i];
        Console.WriteLine($"{row.Cells["Foo"].Value} {row.Cells["Bar"].Value}");
    }
