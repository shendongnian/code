        public partial class MyControl : UserControl
    {
        public MyControl()
        {
            this.InitializeComponent();
            ObjectFactory.BuildUp(this);
        }
        [CustomInject, Browsable(false)]
        public IInjectable Injectable { protected get; set; }
    }
