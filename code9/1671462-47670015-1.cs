    public class Bullet : MonoBehaviour
    {
    
        private void OnCollisionEnter2D(Collision2D collision)
        {
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
    
    }
