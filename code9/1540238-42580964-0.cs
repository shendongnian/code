    public class Movement
        : MonoBehaviour
    {
        Coroutine m_MoveCoroutine;
        float m_SpeedFactor;
    
        void Update()
        {
            // if character is already moving, just return
            if ( m_MoveCoroutine != null )
                return;
            
            // placeholder for the direction
            Vector2 direction; // between { -1, -1 } and { 1, 1 }
            // calculate your direction based on the input
            // and set that direction to the direction variable
            // eg. direction = new Vector2(Input.GetAxisRaw("Horizontal") > 0 ? 1 : -1,...)
            // then check if direction is not { 0, 0 }
            if( direction != Vector2.zero )
            {
                // start moving your character
                m_MoveCoroutine = StartCoroutine(Move(direction));
            }
        }
    
        IEnumerable Move(Vector2 direction)
        {
            // Lerp(Vector2 a, Vector2 b, float t);
            Vector2 orgPos = transform.Position; // original position
            Vector2 newPos = orgPos + direction; // new position after move is done
            float t = 0; // placeholder to check if we're on the right spot
            while( t < 1.0f ) // loop while player is not in the right spot
            {
                // calculate and set new position based on the deltaTime's value
                transform.position = Vector2.Lerp(orgPos, newPos, (t += Time.deltaTime * m_SpeedFactor));
                // wait for new frame
                yield return new WaitForEndFrame();
            }
            // stop coroutine
            StopCoroutine(m_MoveCoroutine);
            // get rid of the reference to enable further movements
            m_MoveCoroutine = null;
        }
    }
