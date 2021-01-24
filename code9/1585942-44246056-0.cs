    public dlgDetailsObj(myInterface item)
    {
        InitializeComponent();
        objGridView.DataSource = new BindingList<dlgItem>();
        var t = new Task(() =>
        {
            ...
        });
        t.Start();
        t.ContinueWith(task =>
        {
            bool displayNameColumn = false;
            bool displayFornameColumn = false;
            bool displayCompanyColumn = false;
            foreach (dlgItem item in (BindingList<dlgItem>)objGridView.DataSource)
            {
                if (!string.IsNullOrEmpty(item.Name))
                    displayNameColumn = true;
                if (!string.IsNullOrEmpty(item.Forname))
                    displayFornameColumn = true;
                if (!string.IsNullOrEmpty(item.Compagny))
                    displayCompanyColumn = true;
            }
            objGridView.Columns[0].Visible = displayNameColumn;
            objGridView.Columns[1].Visible = displayFornameColumn;
            objGridView.Columns[2].Visible = displayCompanyColumn;
        }, System.Threading.CancellationToken.None, TaskContinuationOptions.None, TaskScheduler.FromCurrentSynchronizationContext());
    }
