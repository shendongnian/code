    private List<TypeDocClass> object_TypeDocs = new List<TypeDocClass>();
    private void Form1_Load(object sender, EventArgs e)
    {
        object_TypeDocs = SearchAndPopulateTiers(@"C:\TestLoadFiles", "NUM_CLIENT",sender);
    
        this.listBox1.MouseClick += new MouseEventHandler(listBox1_MouseClick);
    
    }
    
    void listBox1_MouseClick(object sender, MouseEventArgs e)
    {
        if(object_TypeDocs != null)
        {
    
        }
    }
