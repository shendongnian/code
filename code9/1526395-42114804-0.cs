        public class Data
        {
            public string State { get; set; }
        }
        public partial class Actions : Form
        {
            private Data data = new Data();
            public Actions()
            {
                InitializeComponent();
                data.State = "state";
            }
            private void Actions_Load(object sender, EventArgs e)
            {
                testLabel.Text = data.State;
            }
        }
