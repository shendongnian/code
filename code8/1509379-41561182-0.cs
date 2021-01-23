     //saving the default background color of the button to a variable at class level or constructor.
                var x = (SolidColorBrush)backButton.Background;
                
    //logic for the toggle       
                if (!toggle)
                        {
                           button.Background = new SolidColorBrush(Colors.Blue);
                           toggle = true;
                        }
                        else
                        {
                            //restoring the default background color of the button
                            button.Background = x;
                            toggle=false;
                        }
