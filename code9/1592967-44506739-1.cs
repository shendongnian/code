    //Open a control to prompt for instrument.
    Window window = new Window
    {
        Title = "Associate Com Port",
        Content = new MyDialogView(),
        SizeToContent = SizeToContent.WidthAndHeight,
        ResizeMode = ResizeMode.NoResize
    };
    window.ShowDialog();
    //  The view is the window content.
    var view = (MyDialogView)window.Content;
    //  The view XAML created an instance of MyDialogViewModel and assigned it to 
    //  the view's DataContext.
    MyDialogViewModel dlgVM = (MyDialogViewModel)view.DataContext;
    //  Now you've got the viewmodel that was used in the dialog, with all its 
    //  properties intact. 
    MessageBox.Show($"Instrument selected was {dlgVM.InstrumentSelected}");
