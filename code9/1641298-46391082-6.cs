    public partial class MainWindow : Window
    {
      public MainWindow()
      {
        InitializeComponent();
        dg.ItemsSource = Products;
      }
      readonly ObservableCollection<Product> Products = new ObservableCollection<Product>();
      private void btnSubmit_Click(object sender, RoutedEventArgs e) 
      {
        foreach(var product in Products)
        {
          //Save product to database
        }
        Products.Clear();
      }
    public class Product : INotifyPropertyChanged
    {
      string _Item;
      public string Item
      {
        get => _Item;
        set
        {
          _Item = value;
          RaisePropertyChanged();
        }
      }
      decimal _Price;
      public decimal Price
      {
        get => _Price;
        set
        {
          _Price = value;
          RaisePropertyChanged();
          RaiseCostChanged();
        }
      }
      decimal _Discount;
      public decimal Discount
      {
        get => _Discount;
        set
        {
          _Discount = value;
          RaisePropertyChanged();
          RaiseCostChanged();
        }
      }
      decimal _ShippingCost;
      public decimal ShippingCost
      {
        get => _ShippingCost;
        set
        {
          _ShippingCost = value;
          RaisePropertyChanged();
          RaiseCostChanged();
        }
      }
      public decimal Cost => Price + ShippingCost - Discount;
      public event PropertyChangedEventHandler PropertyChanged;
      protected void RaisePropertyChanged([CallerMemberName]string propertyName = null) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
      protected void RaiseCostChanged() => RaisePropertyChanged(nameof(Cost));
    }
