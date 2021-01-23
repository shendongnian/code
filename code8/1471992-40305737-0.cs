    public class TestScript : MonoBehaviour
    {
        #region Attributes
        [SerializeField]
        private float m_MaxTransformSpeed;
    
        [SerializeField]
        private float m_MinStartSpeed;
        [SerializeField]
        private float m_MaxStartSpeed;
    
        private ParticleSystem m_Particles;
        private Vector3 m_PreviousPosition;
        #endregion
    
        #region MonoBehaviour
        protected void Start()
        {
            m_Particles = GetComponent<ParticleSystem>();
        }
    
        protected void Update()
        {
            Vector3 cameraSpeed = transform.position - m_PreviousPosition;
            m_Particles.startSpeed = Mathf.Clamp(m_MinStartSpeed + (m_MaxStartSpeed - m_MinStartSpeed) * cameraSpeed.magnitude / m_MaxTransformSpeed, m_MinStartSpeed, m_MaxStartSpeed);
            m_PreviousPosition = transform.position;
        }
        #endregion
    }
