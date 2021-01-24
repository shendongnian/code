        public class Data
        {
            public string State { get; set; }
        }
        public partial class Actions : Form
        {
            public Data Data { get; set; }
            private void Actions_Load(object sender, EventArgs e)
            {
                testLabel.Text = data.State;
            }
        }
