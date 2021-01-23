    namespace WpfStackOverflow
    {
    /// <summary>
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
    ...
    // Using a DependencyProperty as the backing store for ContextMenuVisibilityMode.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ContextMenuVisibilityModeProperty =
            DependencyProperty.RegisterAttached("ContextMenuVisibilityMode", typeof(string), typeof(Window2), new PropertyMetadata("Extended", new PropertyChangedCallback(OnContextMenuVisibilityModeChanged)));
    
        private static void OnContextMenuVisibilityModeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DataGrid dgrd = d as DataGrid;
            dgrd.ContextMenuOpening += ((sender, args) => {
                if (e.NewValue.ToString() == "Single")
                    args.Handled = (sender as DataGrid).SelectedItems.Count > 1;
                else if (e.NewValue.ToString() == "Extended")
                    args.Handled = !((sender as DataGrid).SelectedItems.Count > 1);
                else { 
                    // do something
                }
            });
        }
    
    ...
    }
