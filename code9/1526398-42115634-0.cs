    public partial class Actions : Form
    {
        public Actions(Data data)
        {
            InitializeComponent();
            testLabel.Text = data.State;
        }
    }
    public class Data
    {
        public string State { get; set; }
        public string Initials { get; set; }
