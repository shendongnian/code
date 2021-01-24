    //using System.Windows.Markup.Primitives;
    //using System.Windows.Controls.Primitives;
    public class GetColumnIdentifier : IValueConverter
    {
        private static T GetVisualAncestor<T>(DependencyObject obj)
            where T : DependencyObject
        {
            while (obj != null)
            {
                if (obj is T)
                    return obj as T;
                else
                    obj = VisualTreeHelper.GetParent(obj);
            }
            return null;
        }
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //  Not all DataGridColumn subclasses have a Binding property. 
            var header = GetVisualAncestor<DataGridColumnHeader>((DependencyObject)value);
            var datagrid = GetVisualAncestor<DataGrid>(header);
            
            if (header?.Column != null)
            {
                MarkupObject markupObject = MarkupWriter.GetMarkupObjectFor(header.Column);
                var bindingProp = markupObject.Properties.FirstOrDefault(p => p.Name == "Binding");
                if (bindingProp?.Value is Binding binding)
                {
                    return $"{datagrid?.Name}.{binding.Path.Path}";
                }
            }
            return null;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
