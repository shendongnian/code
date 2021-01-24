        using System.Runtime.Caching;
        private ObjectCache cache = MemoryCache.Default;
        
        public class Food
        {
            public string Name { get; set; }
            public double Price { get; set; }
        }
        public void AddFood()
        {
            FoodList.Add(new Food { Name = "Pizza", Price = 10 });
            FoodList.Add(new Food { Name = "Fries", Price = 5 });
            cache.Add("UserCacheFood", FoodList, DateTimeOffset.MaxValue);
        }
        public List<Food> ReturnListFromCache()
        {
            return (List<Food>)cache.Get("UserCacheFood");
        }
        private void button1_Click(object sender, EventArgs e)
        {
            AddFood();
            var result = ReturnListFromCache();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            var ret2 = ReturnListFromCache();
        }
