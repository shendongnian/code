    UIView accessoryView = new UIView(new CGRect(100, 100, 320, 144));
    UIButton btn = new UIButton(UIButtonType.System);
    btn.SetTitle("Done", UIControlState.Normal);
    btn.AddTarget((sender, args) =>
    {
        textField.Text = itemList[(int)(pickerView.SelectedRowInComponent(0))];
        textField.ResignFirstResponder();
    }, UIControlEvent.TouchUpInside);
    accessoryView.AddSubview(btn);
    //Place the button at super view's top, right position.
    btn.TranslatesAutoresizingMaskIntoConstraints = false;
    accessoryView.AddConstraint(NSLayoutConstraint.Create(btn, NSLayoutAttribute.Trailing, NSLayoutRelation.Equal, accessoryView, NSLayoutAttribute.Trailing, 1, -10));
    accessoryView.AddConstraint(NSLayoutConstraint.Create(btn, NSLayoutAttribute.Top, NSLayoutRelation.Equal, accessoryView, NSLayoutAttribute.Top, 1, 5));
    textField.InputAccessoryView = accessoryView;
