    public partial class FocusTest
    {
        public FocusTest()
        {
            InitializeComponent();
        }
        private void OnButtonClick(object sender, RoutedEventArgs e)
        {
            _textBox.Text = "";
            System.Reactive.Concurrency.Scheduler.Default.Schedule(
                TimeSpan.FromSeconds(5),
                () => this.Dispatcher.BeginInvoke(new Action(this.SetFocus)));
        }
        private void SetFocus()
        {
            _textBox.Text = "Focused";
            FocusManager.SetFocusedElement(_textBox, _textBox);
        }
    }
