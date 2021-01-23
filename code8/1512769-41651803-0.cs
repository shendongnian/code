    public class fallBridge : MonoBehaviour
    {
        private Rigidbody ball;
        public GameObject bridgePivot;
        bool rotating = false;
    
        void OnCollisionEnter(Collision other)
        {
            ball = GameObject.FindWithTag("Player").GetComponent<Rigidbody>();
            if (other.gameObject.CompareTag("Player") && ball.transform.localScale == new Vector3(2.0f, 2.0f, 2.0f))
            {
                Debug.Log("ENTER");
                Vector3 rotationAngle = new Vector3(0, 0, -85);
                StartCoroutine(RotateObject(bridgePivot, rotationAngle, 3f));
            }
        }
    
        IEnumerator RotateObject(GameObject gameObjectToMove, Vector3 eulerAngles, float duration)
        {
            if (rotating)
            {
                yield break;
            }
            rotating = true;
    
            Quaternion newRot = Quaternion.Euler(gameObjectToMove.transform.eulerAngles + eulerAngles);
    
            Quaternion currentRot = gameObjectToMove.transform.rotation;
    
            float counter = 0;
            while (counter < duration)
            {
                counter += Time.deltaTime;
                gameObjectToMove.transform.rotation = Quaternion.Lerp(currentRot, newRot, counter / duration);
                yield return null;
            }
            rotating = false;
        }
    }
