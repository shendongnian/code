    public static partial class Behaviors
    {
        public static ICommand GetDrop(DependencyObject obj) => (ICommand)obj.GetValue(DropProperty);
        public static void SetDrop(DependencyObject obj, ICommand value) => obj.SetValue(DropProperty, value);
        public static readonly DependencyProperty DropProperty =
            DependencyProperty.RegisterAttached("Drop", typeof(ICommand), typeof(Behaviors), new PropertyMetadata(null, (d, e) =>
            {
                var element = d as UIElement;
                element.Drop += (s, a) =>
                {
                    if (a.Data.GetDataPresent(DataFormats.StringFormat))
                    {
                        var command = (ICommand)e.NewValue;
                        var data = (string)a.Data.GetData(DataFormats.StringFormat);
                        if (command.CanExecute(data))
                            command.Execute(data);
                    }
                };
            }));
    }
