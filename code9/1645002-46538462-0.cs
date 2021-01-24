    using System.Net.Http;
    using Newtonsoft.Json;
    using Xamarin.Forms;
    using System.Collections.ObjectModel;
    using Syncfusion.SfGauge.XForms;
    using System.Collections;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Text;
    using System.Threading.Tasks;
    using Newtonsoft.Json.Linq;
    using System;
    using System.Net;
    
    
    
    
    
        namespace Drip
        {
        
        
            public partial class Guage : ContentPage
            {
                private const string Url = "https://thingspeak.com/channels/301726/field/1.json";
                private HttpClient _client = new HttpClient();
        
        
                private ObservableCollection<Feed> _data2;
        
        
                //SfChart chart;
                //LineSeries series;
        
                public static void parseJson()
                {
                    using (System.Net.WebClient wc = new System.Net.WebClient())
                    {
                        var json = wc.DownloadString(@"https://thingspeak.com/channels/301726/field/1.json");
                        JObject obj = JObject.Parse(json);
                        foreach (var feedObj in obj["feeds"])
                        {
                            Feed feed = JsonConvert.DeserializeObject<Feed>(feedObj.ToString());
                            double field1 = feed.Field1;
                        }
                    }
                }
        
        
                SfCircularGauge circular;
                NeedlePointer needlePointer;
        
                public Guage()
                {
                    InitializeComponent();
        
                    circular = new SfCircularGauge();
                    circular.VerticalOptions = LayoutOptions.FillAndExpand;
                    circular.BackgroundColor = Color.Black;
        
                    Header header = new Header();
                    header.Text = "Water Meter";
                    header.TextSize = 20;
                    header.Position = new Point(0.50, 0.7);
                    header.ForegroundColor = Color.Gray;
                    circular.Headers.Add(header);
        
                    ObservableCollection<Scale> scales = new ObservableCollection<Scale>();
                    Scale scale = new Scale();
                    scale.LabelPostfix = "Litres";
                    scale.StartValue = 0;
                    scale.EndValue = 100;
                    scale.Interval = 10;
                    scale.StartAngle = 135;
                    scale.SweepAngle = 270;
                    scale.RimThickness = 20;
                    scale.RimColor = Color.White;
                    scale.MinorTicksPerInterval = 0;
                    scales.Add(scale);
        
                    Range range = new Range();
                    range.StartValue = 80;
                    range.EndValue = 100;
                    range.Color = Color.DarkRed;
                    range.Thickness = 10;
                    scale.Ranges.Add(range);
                    circular.Scales = scales;
        
        
                    ObservableCollection<NeedlePointer> needle = new ObservableCollection<NeedlePointer>();
                    needlePointer = new NeedlePointer();
                    needlePointer.Color = Color.Gray;
                    needlePointer.KnobColor = Color.Red;
                    needlePointer.Thickness = 5;
                    needlePointer.KnobRadius = 20;
                    needlePointer.LengthFactor = 0.8;
                    needlePointer.Value = 37;
        
                    //needlePointer.SetBinding(NeedlePointer.ValueProperty, "Field1");
                    //this.BindingContext = new Feed();
                    needlePointer.EnableAnimation = true;
                    scale.Pointers.Add(needlePointer);
                    needlePointer.Value = 37;
        
                    this.BindingContext = _data2[0];
                    needlePointer.SetBinding(Pointer.ValueProperty, "field1");
        
                    Content = circular;
                }
        
                protected override async void OnAppearing()
                {
                    var content = await _client.GetStringAsync(Url);
                    var data = JsonConvert.DeserializeObject<RootObject>(content);
                    _data2 = new ObservableCollection<Feed>(data.Feeds);
        
                    base.OnAppearing();
        
        
                }
        
            }
        }
