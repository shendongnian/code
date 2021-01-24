    public class MoveObjectTowards : MonoBehaviour
    {
        public Transform TargetTransform;
        public float Speed;
        private void Update ()
        {
            if (!IsAtTarget())
            {
                MoveTowardsTarget();
            }
        }
        private void MoveTowardsTarget()
        {
            gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, TargetTransform.position,
                Speed * Time.deltaTime);
        }
        private bool IsAtTarget()
        {
            return gameObject.transform.position == TargetTransform.position;
        }
    }
