    public class KeyComponent : Component
    {
        [SerializeField]
        AudioClip m_KeyPickupSound;
        [SerializeField]
        bool m_IsPickedUp;
        public bool PickedUp
        {
            get { return m_IsPickedUp; }
        }
        public void PickUp()
        {
            m_IsPickedUp = true;
        }
    }
