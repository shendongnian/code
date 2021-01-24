    public Form1()
    {
        InitializeComponent();
        for (int i = 1; i < 15; i++)
            checkedListBox1.Items.Add(i);
    }
    private void button1_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < checkedListBox1.Items.Count; i++)
        {
            if (checkedListBox1.GetItemCheckState(i) == CheckState.Checked)
                IdFundosSelecionades.Add((int)checkedListBox1.Items[i]); 
                // added as int, so cast as int
        }
    }
