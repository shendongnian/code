    UIToolbar toolBar = new UIToolbar(new CGRect(0, 0, 320, 44));
    UIBarButtonItem flexibleSpaceLeft = new UIBarButtonItem(UIBarButtonSystemItem.FlexibleSpace,null,null);
    UIBarButtonItem doneButton = new UIBarButtonItem("Done",UIBarButtonItemStyle.Done,this, new ObjCRuntime.Selector("DoneAction"));
    UIBarButtonItem[] list = new UIBarButtonItem[] { flexibleSpaceLeft, doneButton };
    toolBar.SetItems(list, false);
    
    UIPickerView pickerView = new UIPickerView(new CGRect(0, 44, 320, 216));
    pickerView.DataSource = new MyUIPickerViewDataSource();
    pickerView.Delegate = new MyUIPickerViewDelegate();
    pickerView.ShowSelectionIndicator = true;
    
    //Assign the toolBar to InputAccessoryView 
    textField.InputAccessoryView = toolBar;
    textField.InputView = pickerView;
