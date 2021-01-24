    public class AutoDeselectToggleButtonBehavior : Behavior<CommandBar>
    {
        private IEnumerable<AppBarToggleButton> _toggleButtons;
        protected override void OnAttached()
        {
            AssociatedObject.Loaded += OnLoaded;
            base.OnAttached();
        }
        protected override void OnDetaching()
        {
            foreach (var toggle in _toggleButtons)
            {
                toggle.Click -= OnToggleClick;
            }
            AssociatedObject.Loaded -= OnLoaded;
            base.OnDetaching();
        }
        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            // Children extension method:
            // https://github.com/JustinXinLiu/Continuity/blob/master/Continuity/Extensions/UtilExtensions.cs#L25
            _toggleButtons = AssociatedObject.Children().OfType<AppBarToggleButton>();
            foreach (var toggle in _toggleButtons)
            {
                toggle.Click += OnToggleClick;
            }
        }
        private void OnToggleClick(object sender, RoutedEventArgs e)
        {
            var clickedToggle = (AppBarToggleButton)sender;
            foreach (var toggle in _toggleButtons)
            {
                if (toggle != clickedToggle)
                {
                    toggle.IsChecked = false;
                }
            }
        }
    }
