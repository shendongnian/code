    public class ViewModelProductsMain
    {
        public ViewModelProductsMain()
        {
            this.Products = new List<ViewModelProducts>();
            this.TopRated = new List<ViewModelTopRated>();
            this.Featured = new List<ViewModelFeatured>();
        }
        public List<ViewModelProducts> Products { get; set; }
        public List<ViewModelTopRated> TopRated { get; set; }
        public List<ViewModelFeatured> Featured { get; set; }
