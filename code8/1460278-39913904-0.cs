    var frame = sender as Frame;
    FrameworkElement content = frame.Content as FrameworkElement;
    if (content != null) {
        MainViewModel mvm = content.DataContext as MainViewModel;
        // work with mvm...
    }
    else {
        // Frame's content is something unexpected.
    }
