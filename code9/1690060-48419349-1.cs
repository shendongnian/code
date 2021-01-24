        public string MyValue
        {
            get
            {
                return myTextBox.Text;
            }
            set
            {
                myTextBox.Text = value;
            }
        }
        MyWpfApp myApp = new MyWpfApp();
        var text = myApp.MyValue;
      
