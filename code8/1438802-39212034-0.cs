    using System;
    using System.Windows.Forms;
    public class MyRadioButton : RadioButton
    {
        public bool ReadOnly { get; set; }
        protected override void OnClick(EventArgs e)
        {
            if (!ReadOnly)
                base.OnClick(e);
        }
    }
