    public IQueryable<PseudoFood> GetFoods()
    {    
          return (from a in db.Foods
                        orderby a.FoodName descending
                        select new PseudoFood()
                        {
                            FoodName = a.FoodName,
                            FoodID = a.FoodID,
                            Calories = a.Calories,
                            Notes = a.Notes
                        }
                 ).AsQueryable();    
    }
