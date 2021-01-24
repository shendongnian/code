	var generalFact=new AirplaneFactory<IAirplane>();
	generalFact.Add(new F15()); //valid
	generalFact.Add(new Boeing747()); //valid
	var fighterFact = new AirplaneFactory<IFighter>();
	fighterFact.Add(new F15()); //valid	
	var verticalFact=new AirplaneFactory<IVertical>();
	verticalFact.Add(new F14()); //valid
	verticalFact.Add(new F15()); //Invalid
