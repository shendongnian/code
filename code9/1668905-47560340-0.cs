    public class ProductCategoryViewModel : ViewModelBase
    {
        private ObservableCollection<ProductCategory> _productCategories;
        public ObservableCollection<ProductCategory> ProductCategories
        {
            get => _productCategories;
            set => Set(ref _productCategories, value);
        }
        public RelayCommand<string> ClickCategoryCommand { get; set; }
        
        public ProductCategoryViewModel()
        {
            _productCategories = new ObservableCollection<ProductCategory>();
            var p1 = new ProductCategory()
            {
                Description = "P1",
                ChildProductCategories = new List<ProductCategory>()
                {
                    new ProductCategory()
                    {
                        Description = "C1",
                        ChildProductCategories = new List<ProductCategory>()
                        {
                            new ProductCategory()
                            {
                                Description = "C1 C1"
                            },
                            new ProductCategory()
                            {
                                Description = "C1 C2"
                            }
                        }
                    },
                    new ProductCategory()
                    {
                        Description = "C2"
                    }
                }
            };
            _productCategories.Add(p1);
            ClickCategoryCommand = new RelayCommand<string>(Click);
        }
        private void Click(string description)
        {
            MessageBox.Show(description);
        }
    }
