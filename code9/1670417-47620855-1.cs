    using MVVMExample.ViewModel;
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;
    
    namespace MVVMExample
    {
        [XamlCompilation(XamlCompilationOptions.Compile)]
        public partial class TableViewPage : ContentPage
        {
            public TableViewPage()
            {
                InitializeComponent();
                BindingContext = new TableViewPageVM();	//Assing the ViewModel to the binding context!
            }
        }
    }
