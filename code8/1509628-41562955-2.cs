    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }
        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            StorageFile jsonfile = await StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///Assets/test.json"));
            string jsonString = await FileIO.ReadTextAsync(jsonfile);
            var Allhubs = JsonArray.Parse(jsonString);
            //Read json file, and deserialization the json string to Hubcontrol class. 
            List<Hubcontrol> hubsources = new List<Hubcontrol>();
            foreach (IJsonValue jsonValue in Allhubs)
            {
                if (jsonValue.ValueType == JsonValueType.Object)
                {
                    JsonObject hubcontrolitem = jsonValue.GetObject();
                    hubsources.Add(new Hubcontrol()
                    {
                        Title = hubcontrolitem.GetNamedString("Title"),
                        Length = hubcontrolitem.GetNamedString("Length"),
                        Features = hubcontrolitem.GetNamedString("Features")
                    });
                }
            }
            //Create a new hub control, add hubsections which title is got from json
            Hub HubFromJson = new Hub();
            foreach (Hubcontrol hubcontrolitem in hubsources)
            {
                HubSection sectionitem = new HubSection();
                sectionitem.Header = hubcontrolitem.Title;
                HubFromJson.Sections.Add(sectionitem);
            }
            root.Children.Add(HubFromJson);
        }
    }
    public class Hubcontrol
    {
        public string Title { get; set; }
        public string Length { get; set; }
        public string Features { get; set; }
    }
