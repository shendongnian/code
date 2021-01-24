    private void Form1_Load(object sender, EventArgs e)
    {
        ContextMenu contextMenu = new System.Windows.Forms.ContextMenu();
        MenuItem menuItem = new MenuItem("Cut");
        menuItem.Click += new EventHandler(CutAction);
        contextMenu.MenuItems.Add(menuItem);
        menuItem = new MenuItem("Copy");
        menuItem.Click += new EventHandler(CopyAction);
        contextMenu.MenuItems.Add(menuItem);
        menuItem = new MenuItem("Paste");
        menuItem.Click += new EventHandler(PasteAction);
        contextMenu.MenuItems.Add(menuItem);
        richTextBox1.ContextMenu = contextMenu;
    }
    void CutAction(object sender, EventArgs e)
    {
        richTextBox1.Cut();
    }
    void CopyAction(object sender, EventArgs e)
    {
        Clipboard.SetText(richTextBox1.SelectedText);
    }
    void PasteAction(object sender, EventArgs e)
    {
        if (Clipboard.ContainsText())
        {
            richTextBox1.Text
                    += Clipboard.GetText(TextDataFormat.Text).ToString();
        }
    }
