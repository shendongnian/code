    public class DataGridBoundColumn : DataGridTemplateColumn
    {
        public BindingBase Binding { get; set; }
        protected override FrameworkElement GenerateEditingElement(DataGridCell cell, object dataItem)
        {
            var element = base.GenerateEditingElement(cell, dataItem);
            if (element != null && Binding != null)
                element.SetBinding(ContentPresenter.ContentProperty, Binding);
            return element;
        }
        protected override FrameworkElement GenerateElement(DataGridCell cell, object dataItem)
        {
            var element = base.GenerateElement(cell, dataItem);
            if (element != null && Binding != null)
                element.SetBinding(ContentPresenter.ContentProperty, Binding);
            return element;
        }
    }
