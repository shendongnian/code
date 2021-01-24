    private void Add_download_Click(object sender, RoutedEventArgs e)
    {
        int a = 10;
        if (PL.List_Programs.Count > 0)
        {
            a = PL.List_Programs[PL.List_Programs.Count - 1].ProgramID + 1;
        }
        PL.List_Programs.Add(UpdateList(a));
    }
