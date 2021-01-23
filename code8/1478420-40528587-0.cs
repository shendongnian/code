    public class Class1
    {
        private DateTime _isEnabledAfter = DateTime.MinValue;
        public Class()
        {
            listBox1.SelectedValueChanged += new EventHandler(listBox1_SelectedValueChanged);
        }
        public void Pause(int timeMS)
        {
            // set the _isEnabledAfter in the future.
            _isEnabledAfter = DateTime.Now.AddMilliseconds(timeMS);
        }
        public void listBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            // is it after _isEnabledAfter?
            if(DateTime.Now < _isEnabledAfter)
                // nope... do nothing.
                return;
            // do your thing.
        }
    }
