    [ResponseType(typeof(PseudoFood))]
    public IHttpActionResult GetFood(int id)
    {
        //Food food = db.Foods.Find(id);
        PseudoFood food = (from a in db.Foods
                           where a.FoodID == id
                           select new PseudoFood()
                           {
                               FoodName = a.FoodName,
                               FoodID = a.FoodID,
                               Calories = a.Calories,
                               Notes = a.Notes
                           }).FirstOrDefault();
    
        if (food == null)
        {
            return NotFound();
        }
    
        return Ok(food);
    }
