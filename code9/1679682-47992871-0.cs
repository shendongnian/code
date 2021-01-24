        public bool freeRotateTrigger = false;
        public Transform target;
    
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.R))
                freeRotateTrigger = true; 
    
            if (Input.GetKeyUp(KeyCode.R))
                freeRotateTrigger = false;
    
            if (freeRotateTrigger)
            {
                transform.Rotate(Vector3.up, 50f * Time.deltaTime);
            }
            else
            {
                Vector3 relativePos = target.position - transform.position;
                Quaternion rotation = Quaternion.LookRotation(relativePos);
                transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 10f);
            }
        }
