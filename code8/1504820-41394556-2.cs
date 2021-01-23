    public class ViewModel : INotifyPropertyChanged
    {
        public string MyNonStaticProperty
        {
            get { return MyStaticClass.MyStaticProperty; }
            set { MyStaticClass.MyStaticProperty = value; NotifyPropertyChanged(); }
        }
        //...
    }
    public static class MyStaticClass
    {
        public static string MyStaticProperty { get; set; }
    }
