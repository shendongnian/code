    public class StockEntryModel : INotifyPropertyChanged
    {
		...
		
		public void NotifyAllChanged()
		{
			OnPropertyChanged(string.Empty);
		}
	}
	
	       private void ComboBoxCurrency_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var text = ((sender as ComboBox).SelectedItem as ComboBoxItem).Content as string;
            SelectedCurrency.Name = text;
            Console.WriteLine("Currency changed to {0}", text);
			
			StockEntriesCollection?.ForEach(entry=>entry.NotifyAllChanged()); // <==
        }
