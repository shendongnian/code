    public class ObservablePanel : Panel
    {
        protected override void OnVisualChildrenChanged(DependencyObject visualAdded, DependencyObject visualRemoved)
        {
            base.OnVisualChildrenChanged(visualAdded, visualRemoved);
            VisualChildrenChanged?.Invoke(this, EventArgs.Empty);
        }
        public event EventHandler VisualChildrenChanged;
    }
