    public abstract class Combatant : MonoBehaviour
    {
    	//for arguments sake, we are only going to have speed property, attack method which
    	//all instances have to implement, and a defend which only some might implement their
    	//own method for (the rest default to the base class)
    	int speed {get;set;}
    	
    	//Need to have this method in derived classes
    	//We don't define a body, because the derived class needs to define it's own
    	protected abstract void Attack();
    	
    	//Can be overriden in derived class, but if not, falls back to this implementation
    	protected virtual void Defend()
    	{
    		speed *= 0.5; //half speed when defending
    	}
    }
    
    public class MonsterA : Combatant
    {
    	protected override void Attack()
    	{
    		//attack code goes here for MonsterA
    	}
    	
    	//to access speed, we simply need to use base.speed
    	public void SomethingElse()
    	{
    		base.speed *= 1.25;
    	}
        //notice we don't have to provide an implementation for Defend, but we can still access it by calling base.Defend(); - this will then run the base classes implementation of it.
    }
    
    public class MonsterB : Combatant
    {
    	protected override void Attack()
    	{
    		//attack code goes here for MonsterB
    	}
    	
    	//Assume this is a 'heavier' class 'monster', speed will go down more than standard when defending
    	protected override void Defend()
    	{
    		base.speed *= 0.3;
    	}
    }
