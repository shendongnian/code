    private bool leftButtonPressed = false;
    private bool rightButtonPressed = false;   
     
    //Scenario1OutputRoot is the ui element.
    void Scenario1OutputRoot_PointerReleased(object sender, PointerRoutedEventArgs e)
    {
        Windows.UI.Input.PointerPoint pt = e.GetCurrentPoint(Scenario1OutputRoot);
        if (pt.Properties.PointerUpdateKind != Windows.UI.Input.PointerUpdateKind.Other)
        {
            this.buttonPress.Text += (pt.Properties.PointerUpdateKind.ToString() + Environment.NewLine);
            if (pt.Properties.PointerUpdateKind == Windows.UI.Input.PointerUpdateKind.LeftButtonPressed)
            {
                leftButtonPressed = false;
            }
            if (pt.Properties.PointerUpdateKind == Windows.UI.Input.PointerUpdateKind.RightButtonPressed)
            {
                rightButtonPressed = false;
            }
        }              
     }
    void Scenario1OutputRoot_PointerPressed(object sender, PointerRoutedEventArgs e)
    {
        Windows.UI.Input.PointerPoint pt = e.GetCurrentPoint(Scenario1OutputRoot);
        if (pt.Properties.PointerUpdateKind != Windows.UI.Input.PointerUpdateKind.Other)
        {
            this.buttonPress.Text += (pt.Properties.PointerUpdateKind.ToString() + Environment.NewLine);
            if (pt.Properties.PointerUpdateKind == Windows.UI.Input.PointerUpdateKind.LeftButtonPressed)
            {
                leftButtonPressed = true;
            }
            if (pt.Properties.PointerUpdateKind == Windows.UI.Input.PointerUpdateKind.RightButtonPressed)
            {
                rightButtonPressed = true;
            }
       }            
       if (leftButtonPressed && rightButtonPressed)
       {
           this.buttonPress.Text = "both the Left and Right buttons are being pressed ";
       }
    }
    void Scenario1OutputRoot_PointerMoved(object sender, PointerRoutedEventArgs e)
    {
        Windows.UI.Input.PointerPoint pt = e.GetCurrentPoint(Scenario1OutputRoot);
        if(pt.Properties.PointerUpdateKind != Windows.UI.Input.PointerUpdateKind.Other)
        {
            this.buttonPress.Text += (pt.Properties.PointerUpdateKind.ToString() + Environment.NewLine);
            if (pt.Properties.PointerUpdateKind == Windows.UI.Input.PointerUpdateKind.LeftButtonPressed)
            {
                leftButtonPressed = true;
            }
            if (pt.Properties.PointerUpdateKind == Windows.UI.Input.PointerUpdateKind.RightButtonPressed)
            {
                rightButtonPressed = true;
            }
            if (leftButtonPressed && rightButtonPressed)
            {
                this.buttonPress.Text = "both the Left and Right buttons are being pressed ";
           }
       }    
       e.Handled = true;
    }
