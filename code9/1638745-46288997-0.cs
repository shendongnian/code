    public class ColorChanging : MonoBehaviour {
    
    public Color[] colors; // To be set from Unity editor
    public Renderer Rend;  // what's being rendered
    
    private int currentIndex = 0;
    
    void Start ()
    {
        Rend = GetComponent<Renderer> ();
        Rend.enabled = true;
        if (colors.Length > currentIndex)
            Rend.sharedMaterial.color = colors[currentIndex];
    }
    
    // Use update instead of OnMouseDown
    void Update() 
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (materials.Length > currentIndex)
                return;
            currentIndex = (currentIndex + 1) % colors.Length;
            Rend.sharedMaterial = materials [index - 1]; 
        }
    }
