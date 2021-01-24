    try
            {
                IInputElement focusedControl = Keyboard.FocusedElement;
                var foc = focusedControl as TextBox;
                foc.Text += (((sender as Button).Content as Border).Child as TextBlock).Text;
            }
            catch (Exception)
            {
            }
