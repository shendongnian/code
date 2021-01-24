    public class RockTrigger : MonoBehaviour {
    
    	public GameManager gameManager;
    	ParticleSystem myParticleSystem;
    	
    	void Awake()
    	{
    		myParticleSystem = GetComponent<ParticleSystem>();
    	}
    	
    	void OnTriggerEnter(Collider other)
    	{
    		myParticleSystem.Play();
            GetComponent<MeshRenderer>.enabled = false;
    		gameManager.GetComponent<GameManager>().EndGame();
    		
    	}
    }
