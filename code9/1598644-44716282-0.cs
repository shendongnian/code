    public Form1()
    {
        InitializeComponent();
    
        Panel[] arr = new Panel[10];
    
        for (int i = 0; i < arr.Length; i++)
        {
            Panel panel = new Panel();
            panel.Name = "pnl" + i.ToString();
            arr[i] = panel;
        }
    }
