    using UnityEngine;
    public class collisionTest : MonoBehaviour {
       void OnTriggerEnter(Collider trigg)
       {
            if (trigg.gameObject.tag == "Red")
            {
                Debug.Log("I have collided with trigger" + trigg.gameObject.name);
                //do your stuff
            }
        }
    }
