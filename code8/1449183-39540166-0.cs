    class MyCheckBox : CheckBox
    {
        public string FileName { get; set; }
        public void MyMethod()
        {
            if (IsChecked)
            {
                (do something with FileName);
            }
        }
    }
