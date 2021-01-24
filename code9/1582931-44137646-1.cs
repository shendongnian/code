    public partial class FormSwitch : Form {
        public class SwitchEventArgs : EventArgs {
            public bool Status { get; set; }
            public SwitchEventArgs(bool status) { Status = status; }
        }
        
        public event EventHandler<SwitchEventArgs> SwitchEvent;
        private bool _status;
        private string _name;
        public FormSwitch(string name) {
            _name = name;
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e) {
            SwitchEvent(this, new SwitchEventArgs(!_status));
        }
        public void SwitchEventHandler(object sender, SwitchEventArgs e) {
            _status = e.Status;
            Debug.Print($"{_name}: {Bounds} {((Form)sender).Bounds} {_status}");
        }
    }
