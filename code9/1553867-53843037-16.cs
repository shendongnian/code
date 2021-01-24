	class TBase { }
	class TDerived1 : TBase { }
	class TDerived2 : TBase { }
	class TDerived3 : TDerived2 { }
    TBase inst = ...
	if (inst is TDerived1)
	{
		// Handles case TDerived1
	}
	else if (inst is TDerived2)
	{
		// Handles cases TDerived2 and TDerived3
	}
	else if (inst is TDerived3)
	{
		// NOT EXECUTED                            <---  !
	}
