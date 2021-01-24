    [Serializeable]
    public Class ActorProperties{
    
    	public int CurrentHealth;
    	public int MaxHealth;
    	public int Range;
    	
    }
    
    
    public Class Actor : MonoBehaviour{
    	[SerializeField] protected ActorProperties _actorProperties
    	public ActorProperties ActorProperties{
    		get{ return _actorProperties;}
    		set{_actorProperties = value;}
    	}
    }
    
    public Class Character : Actor{
    	// Character specific code
    }
    
    public Class Enemy : Actor{
    	// Enemy specific Code
    }
    
    public Class GameManager : MonoBehaviour{
    	private List<Actor> enemies;
    	private List<Actor> characters;
    	
    	public List<Actor> AllActors{
    		get{ 
    			List<Actor> returnList = new List<Actor>(characters);
    			returnList.AddRange(enemies);
    			return returnList;
    		}
    	}
    
       public Actor GetActorWithHealth(float healthCheck){
           Actor actor = AllActors.Find(x => x.ActorProperties.CurrentHealth == healthCheck);
       }
    }
