    public class Raycaster : MonoBehaviour
    {
        private void Start()
        {
            RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, Vector2.down);
            for (int i = 0; i < hits.Length; ++i)
            {
                Debug.LogFormat("The name of collider {0} is \"{1}\".", 
                    i, hits[i].collider.gameObject.name);
            }
        }
    }
