    private void btnMultiThread_Click(object sender, RoutedEventArgs e)
    {
        Task<int>.Factory.StartNew(() =>
        {
            var numbers = Enumerable.Range(2, range - 1);
        var totalPrimes = numbers
                .AsParallel()
                .Where(n => Enumerable.Range(2, (int)Math.Sqrt(n) - 1).All(i => n % i != 0))
                .Count();
            return totalPrimes;
        }).ContinueWith(() => MessageBox.Show(antecendent.Result.ToString()); // Antecedent result feeds into continuation
    }
