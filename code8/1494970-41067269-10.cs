    using UnityEngine;
    public class Cup : MonoBehaviour
    {
        public Vector3 startPos;
        private float lerp = 0, duration = 1;
        Vector3 theNewPos;
    
        void Awake()
        {
            startPos = transform.position;
            theNewPos = transform.position;
        }
    
        void Start()
        {
    
        }
    
        void Update()
        {
            float thresholdSqr = 0.01f;
    
            if ((theNewPos - transform.position).sqrMagnitude > thresholdSqr)
            {
                lerp += Time.deltaTime / duration;
                transform.position = Vector3.Lerp(startPos, theNewPos, lerp);
            }
            else
            {
                transform.position = theNewPos;
                startPos = transform.position;
            }
        }
    
        public void MoveToSpot(Vector3 pos)
        {
            theNewPos = pos;
            lerp = 0f;
        }
    }
   
