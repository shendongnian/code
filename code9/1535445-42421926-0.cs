    if (hg is HGOperator_Hello)
    {
        var helloHg = (HGOperator_Hello)hg;
    	Console.WriteLine(helloHg._x);
    	Console.WriteLine(helloHg._XLocal);
    }
	else
	{
		var goodbyeHg = (HGOperator_Goodbye)hg;
		Console.WriteLine(goodbyeHg._y);
		Console.WriteLine(goodbyeHg._YLocal);
	}
