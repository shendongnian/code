	class Student: IIndividual, IGuardian
	{
		String IIndividual.Name { get; set; }
		String IIndividual.Number { get; set; }
		String IIndividual.Address { get; set; }
		String IGuardian.Name { get; set; }
		String IGuardian.Number { get; set; }
		String IGuardian.Address { get; set; }
    }
