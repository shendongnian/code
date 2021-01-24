    public class MyControl : MaterialSingleLineTextField
    {
        bool readOnly;
        public bool ReadOnly
        {
            get { return readOnly; }
            set
            {
                readOnly = value;
                GetTextBoxControl().ReadOnly = value;
            }
        }
        private TextBox GetTextBoxControl()
        {
            var f = typeof(MaterialSingleLineTextField).GetField("baseTextBox",
                        System.Reflection.BindingFlags.NonPublic |
                        System.Reflection.BindingFlags.Instance);
            return (TextBox)f.GetValue(this);
        }
    }
