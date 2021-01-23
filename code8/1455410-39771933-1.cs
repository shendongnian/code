    public sealed partial class MainPage : Page
    {
        public List<string> ImageCollection = new List<string> {
            "http://az619822.vo.msecnd.net/files/CanaryIslandsTurtle_EN-US8274101746_1366x768.jpg",
            "http://az619822.vo.msecnd.net/files/ShanghaiElevatedWalkway_EN-US8623422930_1366x768.jpg",
            "http://az619822.vo.msecnd.net/files/SkunkKit_EN-US10705950046_1366x768.jpg",
            "http://az619519.vo.msecnd.net/files/RockyMtFox_EN-US11902018005_1366x768.jpg",
            "http://az608707.vo.msecnd.net/files/Burano_EN-US12610622868_1366x768.jpg",
            "http://az608707.vo.msecnd.net/files/SealionMom_EN-US13623871731_1366x768.jpg",
            "http://az608707.vo.msecnd.net/files/Kestrel_EN-US10433052515_1366x768.jpg"
        };
        public MainPage()
        {
            this.InitializeComponent();
            MyGridView.ItemsSource = ImageCollection;
        }
        private void MyGridView_SizeChanged(object sender, Windows.UI.Xaml.SizeChangedEventArgs e)
        {
            var _panel = (ItemsWrapGrid)MyGridView.ItemsPanelRoot;
            var _actual = VisualStateGroup.CurrentState;
            int _gridColumnNumber;
            switch (_actual.Name)
            {
                case "medium":
                    {
                        _gridColumnNumber = 2;
                        break;
                    }
                case "large":
                    {
                        _gridColumnNumber = 3;
                        break;
                    }
                default:
                    {
                        _gridColumnNumber = 1;
                        break;
                    }
            }
            _panel.ItemWidth = e.NewSize.Width / _gridColumnNumber;
        }
        private void MyGridView_ItemClick(object sender, ItemClickEventArgs e)
        {
            //TODO
        }
    }
