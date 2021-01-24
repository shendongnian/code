            private void _backAreaGrid_OnMouseDown(object sender, MouseButtonEventArgs e)
            {
                Dispatcher.BeginInvoke(
                    DispatcherPriority.ContextIdle,
                    new Action(delegate
                    {
                        _textbox.Focus();
                    }));
            }
