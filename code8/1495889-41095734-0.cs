	private Random _random = new Random();
	
	private int RollDie()
	{
		return _random.Next(1, 7); // 7 is the exclusive max value - so real max is 6
	}
	
	private Pair RollPair()
	{
		return new Pair()
		{
			FirstDie = this.RollDie(),
			SecondDie = this.RollDie()
		};
	}
	
	public void btnRoll_Click(object sender, EventArgs e)
	{
		List<Pair> p1Rolls = Enumerable.Range(0, 50).Select(n => this.RollPair()).ToList();
		List<Pair> p2Rolls = Enumerable.Range(0, 50).Select(n => this.RollPair()).ToList();
	
		foreach (var item in p1Rolls.Except(p2Rolls))
		{
			lstRollDifference.Items.Add(string.Format("Player one has [{0}, {1}] which Player two does not", item.FirstDie, item.SecondDie));
		}
	}
