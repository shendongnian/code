    namespace WpfApplication2
    {
        public class CellElementGeneratedEventArgs : EventArgs
        {
            public FrameworkElement Content { get; set; }
        }
        public delegate void CellElementGeneratedEventHandler(object sender, CellElementGeneratedEventArgs e);
        public class MyDataGridTemplateColumn : DataGridTemplateColumn
        {
            public event CellElementGeneratedEventHandler ElementGenerated;
            protected override FrameworkElement GenerateElement(DataGridCell cell, object dataItem)
            {
                FrameworkElement fe = base.GenerateElement(cell, dataItem);
                if(fe != null)
                    fe.Loaded += Fe_Loaded;
                return fe;
            }
            private void Fe_Loaded(object sender, RoutedEventArgs e)
            {
                if (ElementGenerated != null)
                    ElementGenerated(this, new CellElementGeneratedEventArgs() { Content = sender as FrameworkElement });
            }
        }
    }
