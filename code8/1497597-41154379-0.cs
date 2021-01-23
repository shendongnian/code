    keyboardTimer = new Timer(500);
            keyboardTimer.Elapsed += (sender, e) =>
            {  
                if (Monitor.TryEnter(RemoteControlPage.keyboardLock))
                { 
                    var keyboardStatus = LauncherClient.Instance.GetKeyboardStatus();
                    if (keyboardStatus.Visibility == KEYBOARDVISIBILITY.SHOW)
                    { 
                        //Show keyboard
                    }
                    else if (keyboardStatus.Visibility == KEYBOARDVISIBILITY.HIDE)
                    {
                        //Hide keyboard 
                    }
                    else {
                        Debug.WriteLine("Keyboard = Do Nothing");
                    }
                }
            }; 
