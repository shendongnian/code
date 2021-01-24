    public class CharacterStats : MonoBehaviour 
    {
        bool isPlayer = false;
        // Use this for initialization
        void Start () 
        {
            if(gameObject.tag == 'Player') 
            {
                isPlayer = true;
            }      
        }
    
        // Update is called once per frame
        void Update () 
        {
            health = Mathf.Clamp (health, 0, 100);
        }
    
        public void damage(float damage)
        {
            health -= damage;
            if(health<=0)
            {
                if(isPlayer)
                {
                    // Do Player-only stuff
                }
                
                // Do Stuff for both players and enemies
            }
        }
    }
