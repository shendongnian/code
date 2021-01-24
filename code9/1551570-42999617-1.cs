    public partial class TimerControlsForm : Form {
        // This has to be a Timer object
        public Timer BooyaTimer {get; set;}
    
        private void btn_confirm_Click(object sender, EventArgs e) {
            BooyaaTimer.Interval = Int32.Parse(textBox1.Text);
        }
    }
