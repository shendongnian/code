    private FileInfo[] files;
    public Form1()
    {
        InitializeComponent();
    
        files = new DirectoryInfo(@"C:\Users\User\Pictures").GetFiles("*.jpg", SearchOption.AllDirectories);
        foreach (var file in files)
        {
            listView1.Items.Add(file.Name);
        }
    }
    
    private void button1_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < listView1.SelectedItems.Count; i++)
        {
            var curentItem = listView1.SelectedItems[i];
            foreach (FileInfo file in files)
            {
                if (curentItem.Text == file.Name)
                {
                    listView1.Items.Remove(curentItem);
                    file.Delete();
                    i--;
                }
            }
        }
    }
