    public class Behaviour
    {
        
        public static bool? GetSelectAll(DependencyObject obj)
        {
            return (bool?)obj.GetValue(SelectAllProperty);
        }
        public static void SetSelectAll(DependencyObject obj, bool? value)
        {
            obj.SetValue(SelectAllProperty, value);
        }
        // Using a DependencyProperty as the backing store for SelectAll.  This enables animation, styling, binding, etc...
          public static readonly DependencyProperty SelectAllProperty =
            DependencyProperty.RegisterAttached("SelectAll", typeof(bool?), typeof(Behaviour), new PropertyMetadata(null,
                (o, e) =>
                {
                  
                    DataGrid dg = o as DataGrid;
                    if (dg != null)
                    {
                        bool selctAll = Convert.ToBoolean(e.NewValue);
                        if (selctAll)
                        {
                            dg.SelectAll();
                        }
                        else
                        {
                            dg.UnselectAll();
                        }
                    }
                   
                }));
    }
