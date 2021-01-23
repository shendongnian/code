    public partial class MainWindow
    {
        public MainWindow()
        {
            this.InitializeComponent();
    
            List<OrderViewModel> newList = new List<OrderViewModel>();
    
            newList.Add(new OrderViewModel() { FirstName = "foo", LastName = "bar", Organization = "SO", ZipCode = "666" });
            newList.Add(new OrderViewModel() { LastName = "bar", Organization = "SO", ZipCode = "666" });
            newList.Add(new OrderViewModel() { FirstName = "foo", ZipCode = "666" });
            newList.Add(new OrderViewModel() { FirstName = "foo" });
            newList.Add(new OrderViewModel() { FirstName = "foo", LastName = "bar", Organization = "SO", ZipCode = "666" });
    
            DataContext = newList;
        }
    }
    public static class Extensions
    {
        public static string GenerateShippingLabel(this OrderViewModel order)
        {
            StringBuilder sb = new StringBuilder();
    
            if (order.FirstName != "None")
            {
                sb.AppendFormat("{0} ", order.FirstName);
            }
            if (order.LastName != "None")
            {
                sb.AppendLine(order.LastName);
            }
            else
            {
                sb.AppendLine();
            }
    
            if (order.Organization != "None")
            {
                sb.AppendLine(order.Organization);
            }
            if (order.ZipCode != "None")
            {
                sb.AppendLine(order.ZipCode);
            }
    
            return sb.ToString();
        }
    }
    
    public class ShippingLabelConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is OrderViewModel)
            {
                return (value as OrderViewModel).GenerateShippingLabel();
            }
            return "None"; //isn't it ironic? ;-)
        }
    
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    
    public class OrderViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Organization { get; set; }
        public string ZipCode { get; set; }
    
        public string ShippingLabel
        {
            get
            {
                return this.GenerateShippingLabel();
            }
        }
    }
