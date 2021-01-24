    public Form1(System.Collections.IEnumerable items, 
                 System.Collections.IEnumerable otherItems, 
                 String labelText)
    {
        InitializeComponent();
        listBox2.Items.AddRange(items);
        //  etc.
    }
