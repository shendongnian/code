    public partial class Form1 : Form
    {
        private TimeEnabledEvent _event = new TimeEnabledEvent();
        public Form1()
        {
            InitializeComponent();
            listBox1.SelectedValueChanged += _event.Check(ListBox1_SelectedValueChanged);
            _event.Pause(1000);
        }
        private void ListBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            // do your thing
        }
    }
---
    internal class TimeEnabledEvent
    {
        internal EventHandler Check(EventHandler listBox1_SelectedValueChanged)
        {
            return new EventHandler((ss, ee) =>
            {
                if (DateTime.Now >= _isEnabledAfter)
                    listBox1_SelectedValueChanged(ss, ee);
            });
        }
        private DateTime _isEnabledAfter = DateTime.MinValue;
        public void Pause(int timeMS)
        {
            // set the _isEnabledAfter in the future.
            _isEnabledAfter = DateTime.Now.AddMilliseconds(timeMS);
        }
    }
