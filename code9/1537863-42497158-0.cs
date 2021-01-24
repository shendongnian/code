    public partial class MainWindow : Window
    { 
        public List<SelectedPurchaseItems> SelectedList = new List<SelectedPurchaseItems>();
        public MainWindow()
        {
            DataGridSelectedPurchaseItems.ItemsSource = SelectedList;
        }
    
        private void btnSaveModalSelectItem_Click(object sender, RoutedEventArgs e)
        {  
			SelectedPurchaseItems _value = new SelectedPurchaseItems()
			{
				ItemId = Convert.ToInt32(comboboxSelectItemItem.SelectedValue),
				ItemName = comboboxSelectItemItem.Text,
				PurchasePrice = _purchasePrice,
				Quantity = _quantity,
				UnitOfMeasure = comboboxSelectItemUnitofMeasure.Text,
				Total = _total
			};
			SelectedList.Add(_value);
        }
    }
