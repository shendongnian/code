    // Remove the default entrance transition if existed.
    RegisterPropertyChangedCallback(ItemContainerTransitionsProperty, (s, e) =>
    {
        var entranceThemeTransition = ItemContainerTransitions.OfType<EntranceThemeTransition>().SingleOrDefault();
        if (entranceThemeTransition != null)
        {
            ItemContainerTransitions.Remove(entranceThemeTransition);
        }
    })
