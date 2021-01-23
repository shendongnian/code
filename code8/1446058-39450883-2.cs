    namespace AdmediatorTest
    {
        /// <summary>
        /// An empty page that can be used on its own or navigated to within a Frame.
        /// </summary>
        public sealed partial class MainPage : Page
        {
            public MainPage()
            {
                this.InitializeComponent();
                Init();
    
                LicenseInformation licenseInformation = CurrentAppSimulator.LicenseInformation;
                if (!licenseInformation.ProductLicenses["product2"].IsActive)
                {
                    btn1.Visibility = Visibility.Visible;
                }
                else
                {
                    btn1.Visibility = Visibility.Collapsed;
                }
            }
    
            private async void Init()
            {
                StorageFile proxyFile = await Package.Current.InstalledLocation.GetFileAsync("in-app-purchase.xml");
                await CurrentAppSimulator.ReloadSimulatorAsync(proxyFile);
            }
    
            private async void Button_Click(object sender, RoutedEventArgs e)
            {
                LicenseInformation licenseInformation = CurrentAppSimulator.LicenseInformation;
                if (!licenseInformation.ProductLicenses["product2"].IsActive)
                {
                    try
                    {
                        await CurrentAppSimulator.RequestProductPurchaseAsync("product2");
                        if (licenseInformation.ProductLicenses["product2"].IsActive)
                        {
                            AdMediator.Visibility = Visibility.Collapsed;
                        }
                        else
                        {
                            AdMediator.Visibility = Visibility.Visible;
                        }
                    }
                    catch (Exception)
                    {
                        //rootPage.NotifyUser("Unable to buy " + productName + ".", NotifyType.ErrorMessage);
                    }
                }
                else
                {
                    //rootPage.NotifyUser("You already own " + productName + ".", NotifyType.ErrorMessage);
                }
            }
        }
    }
