    ...
    elementM = (UIElement)XamlReader.Parse(xaml);
    gridM.Children.Add(elementM);
    FrameworkElement fe = elementM as FrameworkElement;
    if (fe != null)
    {
        fe.Loaded += (s, e) => 
        {
            string szTempM = "btnCheckAll";
            Button btnCheckAll = CHelper.FindChild<Button>(fe, szTempM);
            btnCheckAll.Click += btnCheckAll_Click;
        };
    }
