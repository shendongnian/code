    public class CustomGrid : Grid
    {
        private TextBlock tb;
        public CustomGrid(ViewModel model)
        {
            tb = new TextBlock();
            tb.Text = "hello world";
            Children.Add(tb); // just to show something
            Background = new SolidColorBrush(Colors.LightGray);
            DataContext = model;
            var binding = new MouseBinding(ViewModel.ClickCommand, new MouseGesture(MouseAction.LeftClick));
            InputBindings.Add(binding);
            var commandBinding = new CommandBinding(ViewModel.ClickCommand, SelectElementExecute);
            CommandBindings.Add(commandBinding);
        }
        void SelectElementExecute(object sender, ExecutedRoutedEventArgs e)
        {
            // The Window executes the command logic when the user wants to Foo.
            MessageBox.Show("The Window is Fooing...");
        }
    }
