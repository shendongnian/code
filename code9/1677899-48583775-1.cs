    namespace WindowsFormsApp1
    {
        public class CheckComboBoxItem
        {
            public CheckComboBoxItem(string text, bool initialCheckState)
            {
                _checkState = initialCheckState;
                _text = text;
            }
            private bool _checkState = false;
            public bool CheckState
            {
                get { return _checkState; }
                set { _checkState = value; }
            }
            private string _text = "";
            public string Text
            {
                get { return _text; }
                set { _text = value; }
            }
            public override string ToString()
            {
                return "Select Options";
            }
        }
    }
