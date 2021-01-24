    public class Succ : MonoBehaviour
    {
        private Animator animator;
        private void Awake()
        {
            // You can already get a reference to the Animator on Awake
            // This way you do not have to do it on every collision
            animator = GetComponent<Animator>();
        }
        
        // Use OnCollisionEnter2D instead since the code
        // needs to be excecuted only once during the collision
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("succ")
            {
                // Assuming that you only want to trigger an animation once
                // to reflect attacking or colliding, you could use SetTrigger
                // instead. Otherwise you need to use SetBool again to set it
                // back to false. You should then change the Animator parameter 
                // accordingly, from a bool to a trigger.
                animator.SetTrigger("succ");
                Destroy(other.gameObject);
            }  
        }
    }
