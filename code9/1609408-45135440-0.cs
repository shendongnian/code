    public partial class Form1 : Form
    {
        private ManualResetEvent _calcEvent;
        private delegate void ChangeTextMethod(string text);
        private ChangeTextMethod _changeTextHandler;
        public Form1()
        {
            InitializeComponent();
            _calcEvent = new ManualResetEvent(false);
            _changeTextHandler = delegate (string text) {
                textbox1.Text += text;
            };
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Calc(1);
        }
        private void ChangeText()
        {
            textbox1.Text += "Press next to continue";
        }
        public async Task Calc(int x)
        {
            await Task.Run(() => {
                while (x < 4)
                {
                    //My Work
                    textbox1.Invoke(_changeTextHandler, "Press next to continue");
                    //Need to pause the iteration until taking a signal from a button
                    _calcEvent.WaitOne();
                    x = 4;
                }
                textbox1.Invoke(_changeTextHandler, "... continued");
            });
        }
        private void button2_Click(object sender, EventArgs e)
        {
            _calcEvent.Set();
        }
    }
