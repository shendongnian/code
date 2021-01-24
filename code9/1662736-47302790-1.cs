    public Labels()
    {
        InitializeComponent();
        ...
        Loaded += (s, e) =>
        {
            var item = (ListBoxItem)LabelsBox.ItemContainerGenerator.ContainerFromIndex(0);
            item?.Focus();
        };
    }
