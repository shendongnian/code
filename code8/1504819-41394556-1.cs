    public sealed partial class BlankPage1 : Page
    {
        public BlankPage1()
        {
            this.InitializeComponent();
            this.DataContext = this;
        }
        public static string MyWrapperProperty { get { return MyStaticClass.MyStaticProperty; } }
    }
    public static class MyStaticClass
    {
        public static string MyStaticProperty { get { return "Static..."; } }
    }
