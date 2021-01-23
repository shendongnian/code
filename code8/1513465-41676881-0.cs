    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    
    namespace TextBoxLostFocusBehaviorExample
    {
        internal static class TextBoxExtensions
        {
            public static readonly DependencyProperty LostFocusCommandProperty = DependencyProperty.RegisterAttached(
                "LostFocusCommand",
                typeof(ICommand),
                typeof(TextBoxExtensions),
                new PropertyMetadata(default(ICommand), OnLostFocusCommandChanged));
    
            private static void OnLostFocusCommandChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
            {
                TextBox textBox = d as TextBox;
                if (textBox == null)
                {
                    return;
                }
    
                if (e.NewValue != null)
                {
                    textBox.LostFocus += TextBoxOnLostFocus;
                }
            }
    
            private static void TextBoxOnLostFocus(object sender, RoutedEventArgs e)
            {
                TextBox textBox = sender as TextBox;
                if (textBox == null)
                {
                    return;
                }
    
                ICommand command = GetLostFocusCommand(textBox);
                command.Execute(null);
            }
    
            public static void SetLostFocusCommand(DependencyObject element, ICommand value)
            {
                element.SetValue(LostFocusCommandProperty, value);
            }
    
            public static ICommand GetLostFocusCommand(DependencyObject element)
            {
                return (ICommand)element.GetValue(LostFocusCommandProperty);
            }
        }
    }
