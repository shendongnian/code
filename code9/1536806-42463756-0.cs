    public partial class Form1 : Form
    {
        List<Region> _regions = new List<Region>();
        public Form1()
        {
            //Some data to test with
            _regions.Add(new Region() { Name = "AA", DisplayName = "11" });
            _regions.Add(new Region() { Name = "AAAA", DisplayName = "111" });
            _regions.Add(new Region() { Name = "AAAAA", DisplayName = "1111" });
            _regions.Add(new Region() { Name = "BBBBBB", DisplayName = "22222" });
            _regions.Add(new Region() { Name = "CCCCC", DisplayName = "333333" });
            InitializeComponent();
            comboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            comboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            comboBox.DataSource = _regions;
            comboBox.DisplayMember = "DisplayName";
            comboBox.ValueMember = "Name";
            var autoCompleteCollection = new AutoCompleteStringCollection();
            if (_regions != null && _regions.Count() > 0)
                foreach (Region region in _regions)
                    autoCompleteCollection.Add(region.DisplayName);
            comboBox.AutoCompleteCustomSource = autoCompleteCollection;
        }
    }
