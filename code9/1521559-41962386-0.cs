    public partial class MyUserControl : UserControl
    {
        public MyUserControl ()
        {
            InitializeComponent();
	    DataContext = new YourViewModelClass();
            DependencyPropertyDescriptor dpd = DependencyPropertyDescriptor.FromProperty(Label.ContentProperty, typeof(Label));
            if (dpd != null)
            {
                dpd.AddValueChanged(label, OnLabelContentChanged);
            }
        }
        private void OnLabelContentChanged(object sender, EventArgs e)
        {
            var vm = this.DataContext as YourViewModelClass;
            vm.YourCommand.Execute(null);
        }
    }
