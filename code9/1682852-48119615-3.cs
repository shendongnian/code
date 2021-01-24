      public class SpawnController : MonoBehaviour {
        private FPSControllerCollission _fpsControllerCollission;
    
        private void Awake() {
          this._fpsControllerCollission = FindObjectOfType<FPSControllerCollission>();
        }
    
        private void Update() {
          if (this._fpsControllerCollission.IsTriggered) {
            StartCoroutine(nameof(Spawning));
          }
        }
    
        IEnumerator Spawning() {
          Debug.Log("Spawning being called...");
          if (this._fpsControllerCollission == true) {
            Debug.Log("CUSTOMER SHOULD SPAWN!");
            bool countStop = false;
            int counter;
            while (countStop == false) {
    
              yield return new WaitForSeconds(2);
              Debug.Log("Fisher Spawned!");
              
              counter++;
              spawnNewCharacter.SpawnCharacter();
    
              if (counter >= 3) {
                countStop = true;
              }
    
            }
          }
        }
      }
