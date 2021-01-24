    public class MeleeAttackController : MonoBehaviour
    {
    	public SphereCollider kickAttackSphere; // in this case the sphere collider must be child of the right foot
    	public float meleeAttackDamage = 50;
    	public AudioClip kickAttackClip;
    	
    	CapsuleCollider m_capsule;
    
    	void Awake()
    	{
    		kickAttackSphere.isTrigger = true;
    		
    		m_capsule = GetComponent<CapsuleCollider>();
    	}
    	
    	void Event_KickAttack_RightLeg() // invoked by the kick animation events (in case you have many kick animations)
    	{
    		if(CheckSphereAndApllyDamage(kickAttackSphere))
    		{
    			if (kickAttackClip)
    			{
    				AudioSource.PlayClipAtPoint(kickAttackClip, weaponAttackSphere.transform.position); // play the sound
    			}
    		}
    	}
    
    	/// <summary>
    	/// Returns true if the sphere collider overlap any collider with a health script. If overlap any collider also apply a the meleeAttackDamage.
    	/// </summary>
    	bool CheckSphereAndApllyDamage(SphereCollider sphere)
    	{
    		// check if we hit some object with a health script added
    		Collider[] colliders = Physics.OverlapSphere(sphere.transform.position, sphere.radius, Physics.AllLayers, QueryTriggerInteraction.Ignore);
    
    		foreach (Collider collider in colliders)
    		{
    			if (collider == m_capsule) continue; // ignore myself
    
    			Health health = collider.GetComponent<Health>();
    			if (health)
    			{
    				// if the collider we overlap has a health, then apply the damage
    				health.TakeDamage(meleeAttackDamage, transform);
    
    				return true;
    			}
    		}
    
    		return false;
    	}
    }
