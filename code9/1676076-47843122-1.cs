    using System.Windows;
    using System.Windows.Controls;
    
    namespace WpfApp1
    {
        public partial class UserControl1
        {
            public static readonly DependencyProperty PositionProperty = DependencyProperty.RegisterAttached(
                "Position", typeof(Position), typeof(UserControl1),
                new PropertyMetadata(default(Position), PositionPropertyChangedCallback));
    
            public UserControl1()
            {
                InitializeComponent();
            }
    
            private static void PositionPropertyChangedCallback(DependencyObject o, DependencyPropertyChangedEventArgs e)
            {
                if (!(o is UIElement uiElement))
                    return;
    
                var position = (Position) e.NewValue;
                var value = (int) position;
                Grid.SetRow(uiElement, value);
            }
    
            public static void SetPosition(DependencyObject element, Position value)
            {
                element.SetValue(PositionProperty, value);
            }
    
            public static Position GetPosition(DependencyObject element)
            {
                return (Position) element.GetValue(PositionProperty);
            }
        }
    
        public enum Position
        {
            Zero = 0,
            One = 1,
            Two = 2
        }
    }
