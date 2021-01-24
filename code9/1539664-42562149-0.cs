    public class Category : IComparable<Category>
    {
        public int CategoryId { get; internal set; }
        public string CategoryName { get; internal set; }
        public int CompareTo(Category x)
        {
            return String.Compare(x.CategoryName, this.CategoryName, StringComparison.InvariantCulture);
        }
    }
    
    List<Category> categories = new List<Category>();
    categories.Add(new Category {CategoryName = "Cate1"});
    categories.Add(new Category {CategoryName = "Cate2"});
    categories.Sort();
    foreach (var cat in categories)
    {
        Console.WriteLine(cat.CategoryName);
    }
