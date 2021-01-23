    using System;
    					
    public class Program
    {
    	public static void Main()
    	{
    		var scores = new AbilityScores() { Speed = 1, Durability = 1 };
    		var skills = new Skills(scores);
    		
    		Console.WriteLine("Before change: " + skills.GetCurrentScores());
    		
    		scores.Speed = 2;
    		scores.Durability = 0;
    		
    		Console.WriteLine("After change: " + skills.GetCurrentScores());
    		
    	}
    	
    }
    
    public class Skills
    {
        public AbilityScores abilityScores;
     
        public Skills(AbilityScores abilityScores)
        {
            this.abilityScores = abilityScores;
        }
    	
    	public string GetCurrentScores()
    	{
    		return "Speed: " + abilityScores.Speed + ", Durability: " + abilityScores.Durability;
    	}
    
        
    }
    
    public class AbilityScores
    {
    	public int Speed {get; set;}
    	public int Durability {get; set;}
    }
