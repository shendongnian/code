    public class Class1
    {
        public delegate void dlgChangeLabel(string lblName, string newValue);
        public event dlgChangeLabel ChangeLabel;
        public void ChangeLabelText()
        {
            if (ChangeLabel != null)
            {
                ChangeLabel("label2", "SurName");
            }
        }
    }
