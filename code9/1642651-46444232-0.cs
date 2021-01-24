    class Ability
    {
    	public Ability(int cooldown, System.Action _abilityMethod)
    	{
    		CoolDown = cooldown;
    		abilityMethod = _abilityMethod;
    	}
    
    	public int CoolDown { get; set; }
    
    	public void Trigger()
    	{
    		if( abilityMethod != null )
    		{
    			abilityMethod();
    		}
    	}
    	
    	private System.Action abilityMethod;
    }
