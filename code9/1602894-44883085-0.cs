    var bases = Database.Set<Bases>();
    var results =
    	(from pizza in Database.Set<Pizzas>()
    	let pizzaBase = bases.FirstOrDefault(pizzaBase => pizzaBase.Id == pizza.Base.Id)
    	select new PizzaViewModel {
    		Base = pizzaBase?.Name,
    		BaseIngredients = pizzaBase?.Ingredients
    	}).ToList();
