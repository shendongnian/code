    public class ViewModel : ViewModelBase
    {
        public ViewModel()
        {
            QuantityRows = new ObservableCollection<QuantityRow>();
            QuantityRows.Add(new QuantityRow() { ID = 1, Name = "Length" });
            QuantityRows.Add(new QuantityRow() { ID = 2, Name = "Diameter" });
            QuantityRows.Add(new QuantityRow() { ID = 3, Name = "Temperature" });
            QuantityRows.Add(new QuantityRow() { ID = 4, Name = "Pressure" });
            QuantityRows.Add(new QuantityRow() { ID = 5, Name = "Angle" });
        }
        private ObservableCollection<QuantityRow> quantityRows;
        public ObservableCollection<QuantityRow> QuantityRows
        {
            get
            {
                return quantityRows;
            }
            set
            {
                quantityRows = value;
                OnPropertyChanged();
            }
        }
        private QuantityRow selectedQuantityRow;
    
        public QuantityRow SelectedQuantityRow
        {
            get { return selectedQuantityRow; }
            set
            {
                if (selectedQuantityRow != value)
                {
                    selectedQuantityRow = value;
                    OnPropertyChanged();
                }
            }
        }
    }
    public class QuantityRow : ViewModelBase
    {
        public int ID { get; set; }
    
        public string Name { get; set; }
    
    }
