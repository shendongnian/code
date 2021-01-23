    using System.Windows;
    using System.Windows.Controls;
    
    namespace WpfApplication1
    {
        /// <summary>
        /// Interaction logic for UserControl1.xaml
        /// </summary>
        public partial class YesNo : UserControl
        {
            public YesNo()
            {
                InitializeComponent();
            }
    
            public static readonly DependencyProperty FlagProperty = DependencyProperty.Register(
                "Flag", typeof(bool), typeof(YesNo), new PropertyMetadata(default(bool)));
    
            public bool Flag {
                get {
                    return (bool) GetValue(FlagProperty);
                }
                set {
                    SetValue(FlagProperty, value);
                }
            }
        }
    }
