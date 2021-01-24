    using UnityEngine;
    
    namespace TransformUtility
    {
        public class SimpleTranslator : MonoBehaviour
        {
            [Tooltip("The local target position towards we translate this gameObject. A red line is drawn.")]
            public Vector3 m_localTargetPosition = new Vector3(0, 0, 5);
            public float speed = 1;
            public bool pingPong;
            public bool translateOnAwake = true;
            public new AudioSource audio;
    
            Vector3 m_initialPosition, m_targetPosition;
            Transform m_transform;
    
            void Awake()
            {
                m_transform = transform;
                m_initialPosition = m_transform.position;
    
                SetTargetPosition(m_localTargetPosition);
                enabled = translateOnAwake;
            }
    
            void FixedUpdate()
            {
                if (audio && !audio.isPlaying)
                    audio.Play();
    
                m_transform.position = Vector3.MoveTowards(m_transform.position, m_targetPosition, speed * Time.deltaTime);
    
                if (m_transform.position == m_targetPosition)
                {
                    if (pingPong)
                    {
                        SwitchDirection();
                    }
                    else
                    {
                        enabled = false;
    
                        if (audio)
                            audio.Stop();
                    }
                }
            }
    
            public bool isTranslating
            {
                get
                {
                    return enabled;
                }
            }
    
            public void SwitchDirection()
            {
                enabled = true;
    
                if (m_transform.position == m_initialPosition)
                {
                    SetTargetPosition(m_localTargetPosition);
                }
                else
                {
                    m_targetPosition = m_initialPosition;
                }
            }
    
            public void MoveToTargetPosition()
            {
                enabled = true;
                SetTargetPosition(m_localTargetPosition);
            }
    
            public void MoveToInitialPosition()
            {
                m_targetPosition = m_initialPosition;
                enabled = true;
            }
    
            public bool isInInitialPosition
            {
                get
                {
                    return m_transform.position == m_initialPosition;
                }
            }
    
            public bool isInTargetPosition
            {
                get
                {
                    return m_transform.position == m_initialPosition + m_transform.TransformDirection(m_localTargetPosition);
                }
            }
    
            private void SetTargetPosition(Vector3 localPosition)
            {
                m_targetPosition = m_initialPosition + transform.TransformDirection(localPosition);
    
    #if UNITY_EDITOR
                m_endPositionDebug = m_targetPosition;
    #endif
            }
    
    #if UNITY_EDITOR
            Vector3 m_endPositionDebug;
    
            void OnDrawGizmos()
            {
                if (!Application.isPlaying)
                {
                    Debug.DrawRay(transform.position, transform.TransformDirection(m_localTargetPosition), Color.red);
                }
                else
                {
                    Debug.DrawLine(m_initialPosition, m_endPositionDebug, Color.red);
                }
            }
    #endif
        }
    }
