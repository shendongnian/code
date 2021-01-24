    //Get the Done button
    var toolbar = (UIToolbar)Control.InputAccessoryView;
    
    // Replace Xamarin's buttons with custom ones.
    var spacer = new UIBarButtonItem(UIBarButtonSystemItem.FlexibleSpace);
    var doneButton = new UIBarButtonItem();
    doneButton.Title = "OK";
    doneButton.Clicked += (o, a) => Control.ResignFirstResponder();
    toolbar.SetItems(new [] { spacer, doneButton}, false);
