    public class product_new : NK.Objects._product_new
    {
        private int Count_Per_Page;
        private readonly int _CountOP;
        public product_new(int count_per_page)
        {
            this.Count_Per_Page = count_per_page;
            this._CountOP = number_of_pages(count_per_page);
        }
        public int CountOP///////count of pages
        {
            get
            {
                return this._CountOP;
            }
        }
