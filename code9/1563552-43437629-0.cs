    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            var location = e.Location;
            _timePassedSinceLastMove = 0;
        }
        private int _timePassedSinceLastMove;
        private void timer1_Tick(object sender, EventArgs e)
        {
            _timePassedSinceLastMove++;
            if (_timePassedSinceLastMove > 30)
            {
                MouseNotMove3Seconds();
                _timePassedSinceLastMove = 0;
            }
        }
        private void MouseNotMove3Seconds()
        {
            
        }
    }
