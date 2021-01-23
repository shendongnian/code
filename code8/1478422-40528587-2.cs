    public class Class1
    {
        private TimeEnabledEvent _selectedValueChanged = new TimeEnabledEvent();
        public Class1()
        {
            listBox1.SelectedValueChanged += (s, e) =>
            {
                if (_selectedValueChanged.IsEnabled)
                    listBox1_SelectedValueChanged(s, e);
            };
            _selectedValueChanged.Pause(200);
        }
        public void listBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            // do your thing.
        }
    }
---
    public class TimeEnabledEvent
    {
        private DateTime _isEnabledAfter = DateTime.MinValue;
        public void Pause(int timeMS)
        {
            // set the _isEnabledAfter in the future.
            _isEnabledAfter = DateTime.Now.AddMilliseconds(timeMS);
        }
        public bool IsEnabled
        {
            get { return (DateTime.Now >= _isEnabledAfter); }
        }
    }  
