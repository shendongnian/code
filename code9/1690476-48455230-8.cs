    public class MyPickerRenderer : PickerRenderer
    {
        List<string> itemList;
        protected override void OnElementChanged(ElementChangedEventArgs<Picker> e)
        {
            base.OnElementChanged(e);
    
            Picker myPicker = Element;
            itemList = myPicker.Items.ToList();
    
            UITextField textField = Control;
            UIPickerView pickerView = textField.InputView as UIPickerView;
            pickerView.Delegate = new MyPickerViewDelegate(itemList);
        }
    }
