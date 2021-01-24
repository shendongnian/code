    MP.UserControl1 a = new MP.UserControl1();
    a.OnInitialData += UCA_OnInitialData;
    
    private void UCA_OnInitialData(object sender, EventArgs e)
    {
        MP.UserControl1 a = sender as MP.UserControl1;
        a.SetValue(result, off1, a.inputData);
    }
    a.ShowDialog();
