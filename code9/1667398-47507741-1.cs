    public class CellTextTemplateSelector : DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            ContentPresenter presenter = container as ContentPresenter;
            DataGridCell cell = presenter.Parent as DataGridCell;
            DataGridTemplateColumn it = cell.Column as DataGridTemplateColumn;
            if (it.Header == A)
            {
                //return logic depends on where you are adding this class
            }
            else
            {
                //return logic depends on where you are adding this class
            }
    
        }
    }
