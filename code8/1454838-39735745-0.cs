    public class BarrelPush : MonoBehaviour {
    public GameObject thePlayer;
    private GrimScript script;
    private Rigidbody2D rb;
    public float normalMass = 10f;
    public float heavyMass = 100f;
    // Use this for initialization
    void Awake() {
        //script = gameObject.FindGameObjectWithTag("Player").GetComponent<GrimScript>();
        script = thePlayer.GetComponent<GrimScript>();
        rb = gameObject.GetComponent<Rigidbody2D>();
    }
    void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Player") && script.amIRaven)
        {
            rb.mass = heavyMass;
        } else
        {
            rb.mass = normalMass;
                }
    }
    }
