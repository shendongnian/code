    <TextBlock Text="{Binding MyStaticProperty}" />
    public sealed partial class BlankPage1 : Page
    {
        public BlankPage1()
        {
            this.InitializeComponent();
            this.DataContext = this;
        }
        public static string MyStaticProperty { get { return "Static..."; } }
    }
