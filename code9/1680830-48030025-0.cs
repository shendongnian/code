    private async void Button_Click(object sender, RoutedEventArgs e) {
        GeneratorButton.IsEnabled = false;
        ResultMsg.Visibility = Visibility.Visible; //default text of "Fetching data..."
        var tickersString = Tickers.Text;
        if (!string.IsNullOrEmpty(tickersString)) {
            tickersString = tickersString.ToUpper();
            string[] tickers = tickersString.Split(',', ' ');
            if (await GetStockDataAndGenerateCSV(tickers)) {
                ResultMsg.Foreground = Brushes.Green;
                ResultMsg.Text = "Your report was successfully generated.";
            } else {
                ResultMsg.Foreground = Brushes.Red;
                ResultMsg.Text = "There was an error while generating your report. Please try again later.";
            }
        }
        GeneratorButton.IsEnabled = true;
    }
