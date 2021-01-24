        namespace TestNamespace
        {
            public partial class Test :ModelBase
            {
                public Test()
                {
                    InitializeComponent();
                }
            }
        }
    
    namespace TemplateLoader.Lib.Base
    {
        public class ModelBase : DependencyObject, INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;
            public void RaisePropertyChanged(string propertyName)
            {
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
