    public MyView()
    {
         this.InitializeComponent();
         Window.Current.CoreWindow.PointerWheelChanged += CoreWindow_PointerWheelChanged;
    }
    
    private void CoreWindow_PointerWheelChanged(CoreWindow sender, PointerEventArgs args)
    {
         if (!SomeConditionLikeYourScrollViewerIsFocused)
         {
            args.Handled = true;
         }
         else { // do nothing }        
    }
