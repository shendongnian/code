    public static ScrollViewer GetScrollViewer(UIElement element)
    {
        if (element == null) return null;
        ScrollViewer retour = null;
        for (int i = 0; i < VisualTreeHelper.GetChildrenCount(element) && retour == null; i++) {
            if (VisualTreeHelper.GetChild(element, i) is ScrollViewer) {
                retour = (ScrollViewer) (VisualTreeHelper.GetChild(element, i));
            }
            else {
                retour = GetScrollViewer(VisualTreeHelper.GetChild(element, i) as UIElement);
            }
        }
        return retour;
    }
