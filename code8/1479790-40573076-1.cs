    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var data = MyModel.getTestData();
            var dataStr = JsonConvert.SerializeObject(data, Formatting.Indented);
            using (var writer = new StreamWriter(@"d:\data.json", false))
            {
                writer.Write(dataStr);
            }
            using (var reader = new StreamReader(@"d:\data.json"))
            {
                var recs = JsonConvert.DeserializeObject<List<MyModel>>(reader.ReadToEnd());
                cbx.ItemsSource = recs;//cbx is ComboBox
                cbx.DisplayMemberPath = "name";
                cbx.SelectedIndex = 0;
            }
        }
    }
    public class MyModel
    {
        public string name { get; set; }
        public double radius { get; set; }
        public double  mass  { get; set; }
        public static List<MyModel> getTestData()
        {
            return new List<MyModel>
            {
                new MyModel {name = "x1", radius = 1, mass = 1},
                new MyModel {name = "x2", radius = 2, mass = 2},
                new MyModel {name = "x3", radius = 3, mass = 3},
                new MyModel {name = "x4", radius = 4, mass = 4},
            };
        }
    }
