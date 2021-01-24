    public class GiveHero : MonoBehaviour {
        private bool hasCollided = false;
        private void OnTriggerEnter(Collider other){
            if(!hasCollided){
                GetComponent(PlayerInfo).SetHealth(-1); // Decrement the player's health by one.
                hasCollided = true;
            }
         }
    }
