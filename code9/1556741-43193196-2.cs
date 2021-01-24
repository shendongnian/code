    private async void button1_Click(object sender, RoutedEventArgs e)
    {
        IMobileServiceTable<Test> productTest = App.MobileService.GetTable<Test>();
        // This query filters out.
        MobileServiceCollection<Test, Test> products = await productTest
            .Where(Test => Test.test == "Test")
            .ToCollectionAsync();
    
        lb.ItemsSource = products;
    
    }
