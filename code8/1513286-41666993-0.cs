    public Form1(string[] file)
    {
        InitializeComponent();
        area.DragDrop += new DragEventHandler(area_DragDrop);
        area.AllowDrop = true;
        identity ident = new identity();
        ident.ShowDialog();
        if (ident.Authenticated)
        {
             if (file.Length != 0)
                pathstart = file[0];
        }
    }
