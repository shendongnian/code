    private void button1_Click(object sender, EventArgs e)
    {
        this.dataGridView1.DataSource = GetFileInfo();
    }
    
    private List<object> GetFileInfo()
    {
        string[] allPaths = Directory.GetFiles(@"C:\Program Files (x86)\Microsoft Visual Studio 10.0", "*.txt", SearchOption.AllDirectories);
        List<object> list = new List<object>();
    
        foreach (var path in allPaths)
        {
            // Create a new anonymous object
            list.Add(new { File = Path.GetFileName(path) });
        }
    
        return list;
    }
