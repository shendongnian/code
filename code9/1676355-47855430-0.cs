	public static void Main()
	{
		var hero = new Hero();
        hero.Walk();
		Console.WriteLine(String.Format("Current Armo: {0}", hero.Armor));
        hero.Walk();
        Console.WriteLine(String.Format("Current Armo: {0}", hero.Armor));
	}
	
	public class Hero
    {
        public int Armor { get; set; }
        public void Walk()
        {
            this.Armor += 5;
        }
    }
