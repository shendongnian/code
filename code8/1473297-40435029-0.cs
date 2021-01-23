    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            RootObject ro = new RootObject() {Text1 = "Header1JsonData",Text2= "Header2JsonData",Text3= "Header3JsonData"};
            this.DataContext = ro;
        }
    }
    public class RootObject
    {
        public string Text1 { get; set; }
        public string Text2 { get; set; }
        public string Text3 { get; set; }
    }
