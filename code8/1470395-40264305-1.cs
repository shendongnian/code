    public partial class DosAdminProductHierarchy : UserControl {
        DOSAdminProductHrcyViewMode viewModel;
        public DosAdminProductHierarchy(DOSAdminProductHrcyViewModel vm) {
            InitializeComponent();            
            this.viewModel = vm;
            this.DataContext = this.viewModel;
            this.Loaded += async delegate {
                await this.viewModel.GetProductListAsync();
            }      
        }
    }
