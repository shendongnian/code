    public class GridItemsControl : ItemsControl
    {
        protected override DependencyObject GetContainerForItemOverride()
        {
            FrameworkElement fwE = base.GetContainerForItemOverride() as FrameworkElement;
            fwE.SetBinding(Grid.ColumnProperty, "columnNr");
            fwE.SetBinding(Grid.RowProperty, "rowNr");
            return fwE;
        }
    }
