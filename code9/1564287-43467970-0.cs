    private static void OnToggleStateChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        TagToggle ctrl = d as TagToggle;
        if (ctrl != null)
        {
            TheTextBlock.Text = ctrl.IsToggled ? ToggleTrueText. : ToggleFalseText;
        }
    }
