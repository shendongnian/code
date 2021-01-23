    browser.GestureEvent += (sender, args) =>
                {
                    m_Gesture.Add(args.GestureType);
                    if (args.GestureType == GestureType.LONG_PRESS)
                    {
                        //// prepare the main action
                    }
                    if (args.GestureType == GestureType.LONG_TAP)
                    {
                        ////do the main action;
                    }
               }
