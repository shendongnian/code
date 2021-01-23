    public class BallCollisionScript : MonoBehaviour 
    {	
        public Rigidbody Rigid_Body;
    
        void Start()
        {
            Rigid_Body = this.GetComponent<Rigidbody>();
        }
    
        void OnCollisionEnter(Collision collision) 
        {
            if (collision.gameObject.tag.Equals("Ball"))
            {
                BallScript otherBall = collision.gameObject.GetComponent<BallScript>();
                Rigid_Body.AddForce(otherBall.Rigid_Body.velocity);
            }
        }
    }
