    public class CreatureBehaviour
        : MonoBehaviour
    {
        int m_Health = 40;
        public int Health { get { return m_Health; } }
  
        // you can add defense attribute 
        int m_Defense;
        public int Defense { get { return m_Defense; } }
        public void DoDamage(double atkPower)
        {
            // calculate this creature defence agains attack power
            int damage = atkPower - this.Defense;
            m_Health -= damage;
            // check health and other stuff.
        }
    }
