    public override UIView GetView(UIPickerView pickerView, nint row, nint component, UIView view)
    {
        UIView contentView = new UIView(new CGRect(0, 0, UIScreen.MainScreen.Bounds.Size.Width, 80));
    
        UILabel label = new UILabel();
        label.Frame = contentView.Bounds;
        contentView.AddSubview(label);
    
        label.Text = itemList[(int)row];
        //Change the label style
        label.Font = UIFont.SystemFontOfSize(24);
        label.TextColor = UIColor.Red;
    
        return contentView;
    }
