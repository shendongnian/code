	void Main()
	{
		var value = Sample.A | Sample.B;
		var bits = new BitArray(new[] { (int)value });
		
		var enumValues = Enumerable.Range(0, bits.Length).Select(n =>
			((Sample)(bits[n] ? Math.Pow(2, n) : 0)));
	}
	
	enum Sample
	{
		A = 0x1,
		B = 0x2,
		C = 0x4
	}
