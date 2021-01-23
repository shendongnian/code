     public ActionResult index(string category)
    {
      var model = GetListofMeals(category);
      model.insert(0, new MealsViewModel(){ id=0, DisplayName="Alle Speisen", Category = ""}; 
      return View(model);
    }
    public ActionResult Products(int id)
    {
      var model = GetMeal(id);
      return View(model);
    }
    private List<MealsViewModel> GetListofMeals(string category)
    {
      ......
    }
    private MealsViewModel GetMeal(int id)
    {
       .......
    }
