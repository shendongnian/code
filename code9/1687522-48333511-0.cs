    public class MyTextField : UITextField
    {
        private UIDatePicker inputView;
        private UIView inputAccessoryView;
        public override UIView InputView
        {
            get
            {
                if (inputView == null)
                {
                    UIDatePicker datePickerView = new UIDatePicker();
                    var calendar = new NSCalendar(NSCalendarType.Gregorian);
                    var currentDate = NSDate.Now;
                    var components = new NSDateComponents();
    
                    components.Year = -60;
    
                    NSDate minDate = calendar.DateByAddingComponents(components, NSDate.Now, NSCalendarOptions.None);
    
                    datePickerView.MinimumDate = minDate;
                    datePickerView.MaximumDate = NSDate.Now;
                    datePickerView.Mode = UIDatePickerMode.Date;
    
                    inputView = datePickerView;
                }
                return inputView;
            }
        }
    
        public override UIView InputAccessoryView
        {
            get
            {
                if (inputAccessoryView == null)
                {
                    UIToolbar toolbar = new UIToolbar(new CGRect(0, 0, UIScreen.MainScreen.Bounds.Size.Width, 44));
                    UIBarButtonItem item = new UIBarButtonItem(UIBarButtonSystemItem.Done, (sender, args) =>
                    {
                        NSDateFormatter formatter = new NSDateFormatter();
                        formatter.DateFormat = "dd/MM/yyyy HH:mm";
                        this.Text = formatter.ToString(inputView.Date);
                        this.ResignFirstResponder();
                    });
                    UIBarButtonItem flexibleItem = new UIBarButtonItem(UIBarButtonSystemItem.FlexibleSpace, null);
                    toolbar.SetItems((new UIBarButtonItem[] { flexibleItem, item }), false);
    
                    inputAccessoryView = toolbar;
                }
                return inputAccessoryView;
            }
        }
    }
