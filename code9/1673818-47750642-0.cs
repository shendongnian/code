    public partial class Core_System : UserControl
    {
        ProSimConnect connection;
        //dependency property
        public ProSimConnect cn
        {
            get { return (ProSimConnect)GetValue(connectionProperty); }
            set { SetValue(connectionProperty, value); }
        }
        public static readonly DependencyProperty connectionProperty =
            DependencyProperty.Register("cn", typeof(ProSimConnect), typeof(Core_System), new PropertyMetadata(new PropertyChangedCallback(OnPropertySet));
        private static void OnPropertySet(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Core_System ctrl = d as Core_System;
            ctrl.connection = e.NewValue as ProSimConnect;
            //...
        }
        // constructor in UserControl
        public Core_System()
        {
            InitializeComponent();
        }
    }
