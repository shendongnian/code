    public MainPage()
    {
        this.InitializeComponent();
        texts = new List<TextBlock>();
    }
    
    private List<TextBlock> texts;
    
    private void Button_Click(object sender, RoutedEventArgs e)
    {
        IEnumerable<TextBlock> textBlocks = FindVisualChildren<TextBlock>(Mycontrol);
        foreach (var textBlock in textBlocks)
        {
            if (textBlock.Name == "tasksPres")
            {
                texts.Add(textBlock);
            }
        }
        foreach (var item in texts)
        {
            item.Text = "11111111111";
        }
    }
    
    private static IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
    {
        if (depObj != null)
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
                if (child != null && child is T)
                {
                    yield return (T)child;
                }
    
                foreach (T childOfChild in FindVisualChildren<T>(child))
                {
                    yield return childOfChild;
                }
            }
        }
    }
