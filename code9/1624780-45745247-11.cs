	var generalFact=new AirplaneFactory<Airplane>();
	generalFact.Add(new F15()); //valid
	generalFact.Add(new Boeing747()); //valid
	var fighterFact = new AirplaneFactory<Fighter>();
	fighterFact.Add(new F15()); //valid
	fighterFact.Add(new Boeing747()); //Invalid!
