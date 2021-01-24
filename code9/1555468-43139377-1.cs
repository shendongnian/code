    namespace Shweta
    {
        public partial class DataBinding : Window
        {
            public DataBinding()
            {
                InitializeComponent();
                this.DataContext = this;  // Pay attention to this line!
                Setupviewmodel();
            }
            private void Setupviewmodel()
            {
                TextString="this worked";
            }
            public string TextString{get;set;}
        }
    }
