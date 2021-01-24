    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
        GridViewDataColumn deductId = new GridViewDataColumn();
        deductId.UniqueName = "DeductId";
        deductId.Header = "DID";
        deductId.DataMemberBinding = new System.Windows.Data.Binding("DeductId");
        gridView.Columns.Add(deductId);
        GridViewDataColumn checkNo = new GridViewDataColumn();
        checkNo.UniqueName = "CheckNo";
        checkNo.Header = "Check No";
        deductId.DataMemberBinding = new System.Windows.Data.Binding("CheckNo");
        gridView.Columns.Add(checkNo);
        GridViewDataColumn checkDate = new GridViewDataColumn();
        checkDate.UniqueName = "CheckDate";
        checkDate.Header = "Check Date";
        deductId.DataMemberBinding = new System.Windows.Data.Binding("CheckDate");
        gridView.Columns.Add(checkDate);
    }
