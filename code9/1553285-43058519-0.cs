    public class ClickTarget : MonoBehaviour {
    
    private GameObject target; private Vector3 destination; private float distance; private Vector3 tTrans;
    
    public GUIText targetDisplay; public float speed; public GameObject bTarg;
    
    void Start () { targetDisplay.text = ""; distance = 0.0f; target = bTarg; }
    
    void Update () { if(Input.GetButtonDown("Fire1")){ Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); RaycastHit hit; if(Physics.Raycast(ray, out hit)){ if(hit.collider != null){ if(hit.collider.tag == "Unit"){ target = hit.collider.gameObject; targetDisplay.text = "Unit: " + hit.collider.gameObject.name; destination = target.transform.position; target.rigidbody.freezeRotation = false; } if(hit.collider.tag == "Building"){ target = hit.collider.gameObject; targetDisplay.text = "Building: " + hit.collider.gameObject.name; } } } } }
    
    void FixedUpdate(){ if (Input.GetButtonDown ("Fire2") && target.tag == "Unit" && GUIUtility.hotControl == 0) { Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); RaycastHit hit; if(Physics.Raycast(ray,out hit)){ destination = hit.point; } }
    
     tTrans = target.transform.position;
     distance = Vector3.Distance (tTrans, destination);
     if(target.tag == "Unit"){
         if (distance > .2f) {
             target.transform.LookAt (destination);
             target.transform.position = Vector3.MoveTowards (target.transform.position, destination, speed);
             target.rigidbody.freezeRotation = true;
         }
     }
    } }
