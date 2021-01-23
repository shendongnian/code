    public class CustomItemCollection : ObservableCollection<UIElement>
    {
    }
    public class MyRichTextBox : RichTextBox
    {
        public static readonly DependencyProperty EditingCommandsProperty =
             DependencyProperty.Register("EditingCommands", typeof(CustomItemCollection),
             typeof(MyRichTextBox));
        public CustomItemCollection EditingCommands
        {
            get { return (CustomItemCollection)GetValue(EditingCommandsProperty); }
            set { SetValue(EditingCommandsProperty, value); }
        }
    }
