        private void ViewOnTouch(object sender, View.TouchEventArgs eventArgs)
        {
            eventArgs.Handled = false;
            if (_command != null)
            {
                _command.Execute();
            }
        }
