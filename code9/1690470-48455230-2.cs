    pickerView.Delegate = new MyPickerViewDelegate(itemList);
    public class MyPickerViewDelegate: UIPickerViewDelegate
    {
    
        List<string> itemList;
    
        public MyPickerViewDelegate(List<string> list)
        {
            itemList = list;
        }
    }
