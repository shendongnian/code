    public ICommand ZoomInCommand
    {
        get { return (ICommand)GetValue(ZoomInCommandProperty); }
        set { SetValue(ZoomInCommandProperty, value); }
    }
    // Using a DependencyProperty as the backing store for ZoomInCommand.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty ZoomInCommandProperty =
        DependencyProperty.Register("ZoomInCommand", typeof(ICommand), typeof(MyWindow), new PropertyMetadata(null, new PropertyChangedCallback(OnZoomInCommandChanged)));
    ...
    private static void OnZoomInCommandChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        MyWindow wnd = (MyWindow)d;
        //Remove the old key binding if there is one.
        wnd.RemoveInputBinding(e.OldValue as ICommand);
        //Add the new input binding.
        if (e.NewValue != null)
            wnd.InputBindings.Add(new KeyBinding((ICommand)e.NewValue, Key.Add, ModifierKeys.Control));
    }
    private void RemoveInputBinding(ICommand command)
    {
        if (command == null)
            return;
        //Find the old binding if there is one.
        InputBinding oldBinding = null;
        foreach (InputBinding binding in InputBindings)
        {
            if (binding.Command == command)
            {
                oldBinding = binding;
                break;
            }
        }
        //Remove the old input binding.
        if (oldBinding != null)
            InputBindings.Remove(oldBinding);
    }
