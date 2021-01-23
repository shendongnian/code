    private async void btnMultiThread_Click(object sender, RoutedEventArgs e)
    {
        var numbers = Enumerable.Range(2, range - 1);
        var totalPrimes = await Task.Run(()=>CalculatePrimes(numbers));
        MessageBox.Show(totalPrimes.ToString());
    }
    private int CalculatePrimes(IEnumerable<int> numbers)
    {
        return numbers
              .AsParallel()
              .Where(n => Enumerable.Range(2, (int)Math.Sqrt(n) - 1).All(i => n % i != 0))
              .Count());
    }
