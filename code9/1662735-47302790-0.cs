    public Labels()
    {
        InitializeComponent();
        LabelsBox.Focus();
        LabelsBox.SelectedIndex = 0;
        Loaded += (s, e) =>
        {
            var item = (ListBoxItem)LabelsBox.ItemContainerGenerator.ContainerFromIndex(0);
            item.Focus();
        }
    }
