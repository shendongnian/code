    Dictionary<string, int> dictionary;
    public void Form1_Load(object sender, EventArgs e)
    {
        dictionary = new Dictionary<string, int>() { { "A", 1 }, { "B", 2 }, { "C", 3 } };
        dataGridView1.DataSource =  new BindingSource(new DictionaryAdapter(dictionary) , "");
    }
