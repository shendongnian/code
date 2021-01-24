    using MyWebApplication.Models;
    namespace MyWebApplication.DAO
    {
        public class FoodDAO
        {
            public List<Food> GetFoodList()
            {
                var foodList = new List<Food>();
                foodList.Add(new Food
                {
                    Index = 1,
                    NRF63 = 13.4m,
                    Desc = new Desc { Name = "Potato" }
                });
                foodList.Add(new Food
                {
                    Index = 2,
                    NRF63 = 2.15m,
                    Desc = new Desc { Name = "McDonalds" }
                });
                foodList.Add(new Food
                {
                    Index = 3,
                    NRF63 = 8000,
                    Desc = new Desc { Name = "Bacon" }
                });
                return foodList;
            }
        }
    }
    
