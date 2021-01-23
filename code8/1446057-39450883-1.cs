    public class Recording : INotifyPropertyChanged
        {
            private bool isVisible;
    
            public Recording()
            {
            }
    
            public bool IsVisible
            {
                get
                {
                    return isVisible;
                }
    
                set
                {
                    if (value != isVisible)
                    {
                        isVisible = value;
                        OnPropertyChanged("IsVisible");
                    }
                }
            }
    
            public event PropertyChangedEventHandler PropertyChanged;
    
            public void OnPropertyChanged(string propertyName)
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                }
            }
        }
    
        /// <summary>
        /// An empty page that can be used on its own or navigated to within a Frame.
        /// </summary>
        public sealed partial class MainPage : Page
        {
            private Recording recording;
    
            public MainPage()
            {
                this.InitializeComponent();
                Init();
                recording = new Recording();
                recording.IsVisible = false;
                this.DataContext = recording;
              
            }
    
            private async void Init()
            {
                StorageFile proxyFile = await Package.Current.InstalledLocation.GetFileAsync("in-app-purchase.xml");
                await CurrentAppSimulator.ReloadSimulatorAsync(proxyFile);
            }
    
            public async Task<bool> PurchaseProductAsync(string productId)
            {
                try
                {
                    var purchase = await CurrentAppSimulator.RequestProductPurchaseAsync(productId);
                    return purchase.Status == ProductPurchaseStatus.Succeeded || purchase.Status == ProductPurchaseStatus.AlreadyPurchased;
                }
                catch (Exception)
                {
                    // The purchase did not complete because an error occurred.
                    return false;
                }
            }
    
            private async void RemoveAd(object sender, RoutedEventArgs e)
            {
                recording.IsVisible = await this.PurchaseProductAsync("product2");
            }
    
          
        }
    
        public class MyConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, string language)
            {
                if (value is Boolean && (bool)value)
                {
                    return Visibility.Collapsed;
                }
                else
                {
                    return Visibility.Visible;
                }
            }
    
            public object ConvertBack(object value, Type targetType, object parameter, string language)
            {
                throw new NotImplementedException();
            }
        }
