    public void AddGridViewRows(string SuccessProxy, string SuccessURL)
    {
    Console.WriteLine("Called AddGridViewRows");
    dataGridView2.Rows.Insert(0, SuccessProxy, "Passed Splash", SuccessURL);
    Console.WriteLine("Successfully added to grid");
    }
