    private void CoreWindow_KeyDown(Windows.UI.Core.CoreWindow sender, Windows.UI.Core.KeyEventArgs args)
    {
        if (args.VirtualKey == Windows.System.VirtualKey.Up)
        {
            upMovement = true;
        }
        else if (args.VirtualKey == Windows.System.VirtualKey.Down)
        {
            downMovement = true;
        }
        else if (args.VirtualKey == Windows.System.VirtualKey.Left)
        {
            leftMovement = true;
        }
        else if (args.VirtualKey == Windows.System.VirtualKey.Right)
        {
            rightMovement = true;
        }
    }
