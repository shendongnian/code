    public Form1(System.Collections.IEnumerable listBoxItems, 
                 System.Collections.IEnumerable otherListBoxItems, 
                 String labelText)
    {
        InitializeComponent();
        listBox2.Items.AddRange(listBoxItems);
        //  etc.
    }
