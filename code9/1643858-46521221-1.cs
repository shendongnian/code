    public sealed class VariableGrid : GridView
    {
        public VariableGrid()
        {
            this.DefaultStyleKey = typeof(VariableGrid);
        }
        protected override void PrepareContainerForItemOverride(DependencyObject element, object item)
        {
            var list = this.ItemsSource as List<string>;      
            var griditem = element as GridViewItem;          
            for (var t = ((list.Count - list.Count % 4)); t < list.Count; t++)
            {
                if (item as string == list[t])
                {
                    if (griditem != null)
                    {
                        VariableSizedWrapGrid.SetColumnSpan(griditem, 2);
                    }
                }
            }
            base.PrepareContainerForItemOverride(element, item);
        }
    }
