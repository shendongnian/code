    private async void UIElement_OnDownKey(CoreWindow sender, KeyEventArgs e)
    {
        Image myImage = GetFrontImage();
        switch(e.VirtualKey)
        {
            case Windows.System.VirtualKey.Down: //Same thing for Up. 
            {
                 myImage.Width = myImage.Width * 0.98;
                 myImage.Height = myImage.Height * 0.98;
                 break;
            }
        }
    }
