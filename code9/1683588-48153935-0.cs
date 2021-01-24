    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    using System.Windows.Markup;
    namespace WpfTest
    {
        [ContentProperty("Message")]
        public class MessagePane : Control
        {
            public static readonly DependencyProperty TextWrappingProperty =
                TextBlock.TextWrappingProperty.AddOwner(
                    typeof(MessagePane),
                    new FrameworkPropertyMetadata(TextWrapping.WrapWithOverflow));
            public TextWrapping TextWrapping
            {
                get { return (TextWrapping)GetValue(TextWrappingProperty); }
                set { SetValue(TextWrappingProperty, value); }
            }
            public static readonly DependencyProperty MessageProperty =
                DependencyProperty.Register(
                    "Message",
                    typeof(string),
                    typeof(MessagePane),
                    new PropertyMetadata(default(string)));
            public string Message
            {
                get { return (string)GetValue(MessageProperty); }
                set { SetValue(MessageProperty, value); }
            }
            static MessagePane()
            {
                DefaultStyleKeyProperty.OverrideMetadata(
                    typeof(MessagePane),
                    new FrameworkPropertyMetadata(typeof(MessagePane)));
                CommandManager.RegisterClassCommandBinding(
                    typeof(MessagePane),
                    new CommandBinding(
                        ApplicationCommands.Copy,
                        (sender, args) =>
                        {
                            var messagePane = sender as MessagePane;
                            if (messagePane != null)
                                Clipboard.SetText(messagePane.Message);
                        }));
            }
            protected override void OnPreviewMouseDown(MouseButtonEventArgs e)
            {
                this.Focus();
                base.OnPreviewMouseDown(e);
            }
        }
    }
