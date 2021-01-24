    commandBar = GetTemplateChild("MediaControlsCommandBar") as CommandBar;
            compactOverlayButton = GetTemplateChild("CompactOverlayButton") as AppBarButton;
    if (CompactOverlayButtonVisibility != Visibility.Visible)
        commandBar.PrimaryCommands.Remove(compactOverlayButton);
    else if(!commandBar.PrimaryCommands.Contains(compactOverlayButton))
        commandBar.PrimaryCommands.Insert(4, compactOverlayButton);
    compactOverlayButton.Visibility = Visibility.Visible;
