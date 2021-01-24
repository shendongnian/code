        public partial class MyControl : UserControl
        {        
            public MyControl()
            {
                InitializeComponent();
    
    		    // _textCity - is a TextBox defined in XAML
      	        VirtualKeyboardHelper.SetAdjustmentOnFocus(this, _textCity, 400);
                VirtualKeyboardHelper.SetAdjustmentOnFocus(this, _textState);
      	    }
        }
