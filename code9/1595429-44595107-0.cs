    public class MoveObjectTowards : MonoBehaviour
    {
        public Transform TargetTransform;
        public float Speed;
    
        private void Update ()
        {
            gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, TargetTransform.position,
                Speed * Time.deltaTime);
        }
    }
