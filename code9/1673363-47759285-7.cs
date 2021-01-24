        public class GiveHero : MonoBehaviour {
        private void OnTriggerEnter(Collider other){
            GetComponent<PlayerInfo>().SetHealth(-1); // Decrement the player's health by one.
            Destroy(other.gameObject); // Remove the Game Object the player collided with.
         }
    }
