    class PageViewModel : INotifyPropertyChanged
        {
            List<Category> Categories;
        public event PropertyChangedEventHandler PropertyChanged;
        public PageViewModel()
        {
            this.Categories = //API call to retrieve the categories
        }
        public List<Category> Categories
        {
            set
            {
                if (Categories != value)
                {
                    Categories = value;
                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this,
                            new PropertyChangedEventArgs("Categories"));
                    }
                }
            }
            get
            {
                return Categories;
            }
        }
    }
