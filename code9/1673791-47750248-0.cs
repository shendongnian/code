    public class Character : MonoBehaviour 
    {
    	public float Health;
    
    	public virtual void Damage(float damageValue) 
    	{
    		Health -= damageValue;
    	}
    
    	public virtual void Die()
    	{
    
    	}
    }
    
    public Enemy : Character
    {
    	public override void Die()
    	{
    		// do enemy related stuff
    	}
    }
    
    public Player : Character
    {	
    	public override void Die()
    	{
    		// do player related stuff.
    		// like game over screen
    	}
    }
