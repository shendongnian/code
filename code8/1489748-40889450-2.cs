    public class NewCast : MonoBehaviour
    {
    
    
    private RaycastHit hit;
    
    bool soundPlayed = false;
    
    [SerializeField]
    private AudioSource source;
    
    
    [SerializeField]
    private AudioClip clip1;
    
    
    private void Start()
    {
        source.clip = clip1;
    }
    
    private void Update(){
        if(Physics.Raycast(transform.position, transform.forward, out hit,9f)){
            if (!soundPlayed && hit.collider.gameObject.name == "Cube"){
                if (!source.isPlaying){
                    source.Play();
                    soundPlayed = true;
                }
            }
        }else{
           if(soundPlayed) soundPlayed = false;
        } 
    }
    
    }
