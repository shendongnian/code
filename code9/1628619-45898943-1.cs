    public class PlattformLooper : MonoBehaviour {
    
    public float spacingBetweenLoops = 0f;
    
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Plattform")
        {
            Debug.Log("TRIGGERED Plattform!");
    
            float heightOfBGObj = ((BoxCollider2D)collider).size.y;
    
            Vector3 pos = collider.transform.position;
    
            pos.y += heightOfBGObj * (5*5)+spacingBetweenLoops;
    
            collider.transform.position = pos;
            collider.GetComponent<YourComponent>().RandomizeHeight();
        }
    }
