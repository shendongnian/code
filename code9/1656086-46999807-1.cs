    interface Base
    {
    	Status Abilities { get; }
    }
    
    class Player : Base
    {
    	public Status Abilities { get; set; }
    }
