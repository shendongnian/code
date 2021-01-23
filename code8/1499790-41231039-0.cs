    protected override void OnPreviewKeyDown(KeyEventArgs e)
                {
                    if (IsReadOnly)
                    {
                        if (e.Key == Key.Down || e.Key == Key.Up)
                        {
                            e.Handled = true;
                            return; // do not call the base class method OnPreviewKeyDown()
                        }
                    }
    
                    base.OnPreviewKeyDown(e);
                }
