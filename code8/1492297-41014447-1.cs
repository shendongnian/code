    public static  void OpacityWithChildren_Light(object sender, int delay)
    {
        var storyboardOfSetOpacityToZero = new Storyboard();
        var storyboardFadeIn = new Storyboard();
        UIElement rootElement = sender as UIElement;
        int childCount = VisualTreeHelper.GetChildrenCount(rootElement);
        if (childCount > 0)
        {
            for (int index = 0; index < childCount; index++)
            {
                UIElement element = (UIElement)VisualTreeHelper.GetChild(rootElement, index);
                var SetOpacityToZero = SingleAnimations.SetToZero(element);
                var SetOpacityToOne = SingleAnimations.SimpleElementFadeIn(element, 100, delay * index);
                storyboardOfSetOpacityToZero.Children.Add(SetOpacityToZero);
                storyboardFadeIn.Children.Add(SetOpacityToOne);
            }
            storyboardOfSetOpacityToZero.Begin();
            storyboardOfSetOpacityToZero.Completed += (s, e) => { storyboardFadeIn.Begin(); };
        }
    }
