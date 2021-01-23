    private async void btnMultiThread_Click(object sender, RoutedEventArgs e)
    {
        var numbers = Enumerable.Range(2, range - 1);
        var totalPrimes = await Task.Run(()=>
            numbers
            .AsParallel()
            .Where(n => Enumerable.Range(2, (int)Math.Sqrt(n) - 1).All(i => n % i != 0))
            .Count());
        MessageBox.Show(totalPrimes.ToString());
    }
