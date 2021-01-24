    this.dataGridView1.Columns[2].Name = "column3";
    this.dataGridView1.Columns[1].Visible = false;
    Console.WriteLine(this.dataGridView1.Columns["column3"].Index);
    // Output: 2
    this.dataGridView1.Columns.RemoveAt(1);
    Console.WriteLine(this.dataGridView1.Columns["column3"].Index);
    // Output: 1
