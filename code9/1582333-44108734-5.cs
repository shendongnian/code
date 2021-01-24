	var p = new ProductionHandlerExample();
	p.Suppliers.Add(new Florist());
	p.Suppliers.Add(new Rosy());
	p.Suppliers.Add(new CarDealer());
	
	//p.GetSuppliers<Flower>() -> Florist, Rosy
	//p.GetSuppliers<Rose>() -> Rosy
	//p.GetSuppliers<Item>() -> all items  (Florist, Rosy, CarDealer)
	//in the example setup, each supplier has a pile of 4
	p.TestOutput(); //Flower(s): 4, Rose(s): 4, Car(s): 4
	p.TryRequest(new Request<Rose>{Amount = 2}); //returns true 
	p.TestOutput(); //Flower(s): 4, Rose(s): 2, Car(s): 4
	p.TryRequest(new Request<Car>{Amount = 5}); //returns false, there are only 4 cars
	p.TestOutput(); //Flower(s): 4, Rose(s): 2, Car(s): 0
	p.TryRequest(new Request<Flower>{Amount = 5}); //returns true, stock of both florist and Roses are used
	p.TestOutput(); //Flower(s): 0, Rose(s): 1, Car(s): 0
