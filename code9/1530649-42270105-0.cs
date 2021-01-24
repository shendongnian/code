	public class switchCharacter : MonoBehaviour
	{
	    public GameObject Psyco1;
	    public GameObject Psyco2;
	    private PlayerControllerPsyco1 script1;
	    private PlayerControllerPsyco1 script2;
	    public Sprite sprite1; // Psyco1 color
	    public Sprite sprite2; // Psyco2 decolorized
	    private SpriteRenderer spriteRendererPsyco1;
	    private SpriteRenderer spriteRendererPsyco2;
	
	    void Start()
	    {
	        script1 = Psyco1.GetComponent<PlayerControllerPsyco1>();
	        script2 = Psyco2.GetComponent<PlayerControllerPsyco1>();
	        script1.enabled = true;
	        script2.enabled = false;
	        spriteRendererPsyco1 = Psyco1.GetComponent<SpriteRenderer>();
	        spriteRendererPsyco2 = Psyco2.GetComponent<SpriteRenderer>();
	        if(spriteRendererPsyco1.sprite == null) // if the sprite on spriteRenderer is null then
	            spriteRendererPsyco1.sprite = sprite1; // set the sprite to Psyco1 Color
	    }
	
	    void Update()
	    {
	        if(Input.GetButtonDown("switch1"))
	        {
	            script1.enabled = !script1.enabled;
	            script2.enabled = !script2.enabled;
	            //spriteRendererPsyco1.sprite = sprite2;
	            DesaturizePsyco(); // call method to change Psyco sprite
	        }
	    }
	
	    void DesaturizePsyco()
	    {
	        if(spriteRendererPsyco1.sprite == sprite1) // if the spriteRenderer sprite = sprite1 then change to sprite2
	        {
	            GameObject.Find("PlayerFirst").GetComponent<SpriteRenderer>().sprite = sprite2;
	        }
	        else
	        {
	            spriteRendererPsyco1.sprite = sprite1; // otherwise change it back to sprite1
	        }
	    }
	}
