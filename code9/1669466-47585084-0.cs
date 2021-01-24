    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    namespace WPF_Question_Answer_App
    {
        public partial class MouseMoveCommandUserControl : UserControl
        {
            public MouseMoveCommandUserControl()
            {
                InitializeComponent();
                MouseMove += (s, e) =>
                {
                    if (MouseMoveCommand.CanExecute(MouseMoveCommandParameter))
                        MouseMoveCommand.Execute(MouseMoveCommandParameter);
                };
            }
    
            public ICommand MouseMoveCommand
            {
                get => (ICommand)GetValue(MouseMoveCommandProperty);
                set => SetValue(MouseMoveCommandProperty, value);
            }
    
            public static readonly DependencyProperty MouseMoveCommandProperty =
                DependencyProperty.Register(nameof(MouseMoveCommand), typeof(ICommand), typeof(MouseMoveCommandUserControl), new PropertyMetadata(null));
    
            public object MouseMoveCommandParameter
            {
                get => GetValue(MouseMoveCommandParameterProperty);
                set => SetValue(MouseMoveCommandParameterProperty, value);
            }
    
            public static readonly DependencyProperty MouseMoveCommandParameterProperty =
                DependencyProperty.Register(nameof(MouseMoveCommandParameter), typeof(object), typeof(MouseMoveCommandUserControl), new PropertyMetadata(null));
        }
    }
