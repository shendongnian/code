	Console.WriteLine("------- Find items using string expression ------");		
	//use string expression
	var predicate = MyDynamics.GetPredicate<Part>("PartId==1444");
	//pass  the predicate to List.Find
	var part= parts.Find(predicate);
	Console.WriteLine("Part: Find: PartId= {0} , PartName={1}",part.PartId, part.PartName);
		
