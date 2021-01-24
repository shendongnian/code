    private void Textbox_TextChanged(object sender, TextChangedEventArgs e)
    {            
        textbox.FontSize = 24;
        textbox.UpdateLayout();
    
        ScrollViewer sv = FindVisualChild<ScrollViewer>(textbox);
    
        if (sv != null)
        {
            Visibility VerticalScrollbarVisibility = sv.ComputedVerticalScrollBarVisibility;
            if (VerticalScrollbarVisibility == Visibility.Visible)
            {
                while (VerticalScrollbarVisibility == Visibility.Visible)
                {
                    textbox.FontSize = textbox.FontSize - 1;
                    textbox.UpdateLayout();
                    VerticalScrollbarVisibility = sv.ComputedVerticalScrollBarVisibility;
                }
            }
        }            
    }
