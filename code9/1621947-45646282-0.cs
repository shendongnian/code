    public class PopupHost : Window
    {
        private readonly AwaitableViewModelBase _viewModel;
        public PopupHost(Window owner, AwaitableViewModelBase viewModel, string dataTemplateKey = null)
        {
            Owner = owner;
            _viewModel = viewModel;
            // Wrap the content in another presenter -- makes it a little easier to get to in order to look for attached properties.
            var contentPresenter = new ContentPresenter
            {
                Content = viewModel
            };
            if (!string.IsNullOrWhiteSpace(dataTemplateKey))
                contentPresenter.ContentTemplate = (DataTemplate) FindResource(dataTemplateKey);
            Content = contentPresenter;
            Task.Run(async () =>
            {
                await viewModel.Task;
                Dispatcher.Invoke(Close);
            });
            Closed += ClosedHandler;
            ApplyTemplate();
            // Grab attached property values from the user control (or whatever element... you just need to find the descendant)
            var contentElement = FindDescendantWithNonDefaultPropertyValue(contentPresenter, PopupWindowProperties.TitleProperty);
            if (contentElement != null)
            {
                var binding = new Binding { Source = contentElement, Path = new PropertyPath(PopupWindowProperties.TitleProperty) };
                SetBinding(TitleProperty, binding);
            }
        }
        private void ClosedHandler(object sender, EventArgs args)
        {
            _viewModel?.Cancel();
            Closed -= ClosedHandler;
        }
        private static Visual FindDescendant(Visual element, Predicate<Visual> predicate)
        {
            if (element == null)
                return null;
            if (predicate(element))
                return element;
            Visual foundElement = null;
            (element as FrameworkElement)?.ApplyTemplate();
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(element); i++)
            {
                var visual = VisualTreeHelper.GetChild(element, i) as Visual;
                foundElement = FindDescendant(visual, predicate);
                if (foundElement != null)
                    break;
            }
            return foundElement;
        }
        private static Visual FindDescendantWithNonDefaultPropertyValue(Visual element, DependencyProperty dp)
        {
            return FindDescendant(element, e => !(dp.GetMetadata(e).DefaultValue ?? new object()).Equals(e.GetValue(dp)));
        }
    }
