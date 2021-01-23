    public class rotationAnimation : MonoBehaviour
    {
       public float rotationMaxAngle = 180 ;
        void Update ()
        {
            if( transform.localEulerAngles.y < rotationMaxAngle )
            {
                float translation = Time.deltaTime * 30;
                transform.Rotate (Vector3.up, translation, Space.World);
            }
        }
    }
