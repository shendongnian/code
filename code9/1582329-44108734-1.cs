	var p = new ProductionHandlerExample();
	p.Suppliers.Add(new Florist());
	p.Suppliers.Add(new Rosy());
	p.Suppliers.Add(new CarDealer());
	
	foreach(var suppl in p.GetSuppliers<Flower>()) Console.WriteLine(suppl); //Florist + Rosy
	foreach(var suppl in p.GetSuppliers<Rose>()) Console.WriteLine(suppl); //Rosy
	foreach(var suppl in p.GetSuppliers<Item>()) Console.WriteLine(suppl); //all items
