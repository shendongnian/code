    private void myEvent(object sender, PointerRoutedEventArgs e)
    {
        Button btn = sender as Button;
        if (btn != null)
        {
            //button was clicked...
        }
        else
        {
            HyperlinkButton hpl = sender as HyperlinkButton;
            if (hpl != null)
            {
                //hyperlink was clicked...
            }
        }
    }
