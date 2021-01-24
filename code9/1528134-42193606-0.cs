    private void HamburgerExecute(object obj)
    {
        SplitView navigation = obj as SplitView;
        navigation.IsPaneOpen = !navigation.IsPaneOpen;
    }
