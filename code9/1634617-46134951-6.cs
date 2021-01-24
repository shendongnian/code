    var parentVC = this; // This would the "main" Form's ViewController, obtain it within your renderer
    PopoverDelegate popoverDelegate = null;
    var datePicker = new UIDatePicker(new CGRect(0, 0, parentVC.View.Frame.Width, 300));
    popoverDelegate = new PopoverDelegate(datePicker, (date) =>
    {
        // Post the date change back to Forms via an event, etc... 
        Console.WriteLine($"Date Choosen: {date}");
        datePicker.Dispose();
        popoverDelegate.Dispose();
    });
    using (var popOverStyleVC = new UIViewController
    {
        ModalPresentationStyle = UIModalPresentationStyle.Popover
    })
    {
        var pc = popOverStyleVC.PopoverPresentationController;
        {
            pc.Delegate = popoverDelegate;
            pc.SourceView = parentVC.View;
            pc.SourceRect = imageButton.Frame; // a CGRect where you want the popup arrow to point
        }
        popOverStyleVC.PreferredContentSize = datePicker.Frame.Size;
        popOverStyleVC.View.Add(datePicker);
        parentVC.PresentViewController(popOverStyleVC, true, null);
    }
