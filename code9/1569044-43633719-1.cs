    <ItemsControl x:Name="ic" />
----------
    public GenerateButtonView()
    {
        InitializeComponent();
        List<Button> listOfButtons = new List<Button>();
        for (int x = 0; x <= gb.ListDistinctAutoName().Count; x++)
        {
            Button b = new Button();
            b.Content = "button" + x.ToString();
            listOfButtons.Add(b);
        }
        ic.ItemsSource = listOfButtons;
    }}
