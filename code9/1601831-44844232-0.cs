	public interface IHero
	{
		string Name { get; }
		int Level { get; }
		IHero LevelUp();
	}
	
