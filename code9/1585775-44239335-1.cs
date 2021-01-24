    class Class1
    {
        Form1 _mainForm;
        public Class1(Form1 form)
        {
            _mainForm = form;    
        }
        public void ChangeLabelText()
        {
            //Form1 frm1 = new Form1();
            //frm1.ChangeLabel("Surname", label2);
            _mainForm.Surname = "Surname";
        }
    }
