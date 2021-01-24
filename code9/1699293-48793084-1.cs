    public MainWindow()
            {
                InitializeComponent();
                Border panel = new Border();
                Grid.SetColumn(panel, 3);
                Grid.SetRow(panel, 3);
    
                StackPanel stack = new StackPanel();
                panel.Child = stack;
    
                Label hasta = new Label();
                hasta.Content = "Test";
                hasta.PreviewMouseLeftButtonDown += PreviewMouseLeftButtonDownEvent;
                stack.Children.Add(hasta);
    
    
                Label hastalik = new Label();
                hastalik.Content = "MM";
                hastalik.PreviewMouseLeftButtonDown += PreviewMouseLeftButtonDownEvent;
                stack.Children.Add(hastalik);
    
                Grid.Children.Add(panel);
            }
    
            protected void PreviewMouseLeftButtonDownEvent(object sender, EventArgs e)
            {
                MessageBox.Show(((Label)sender).Content.ToString());
            }
