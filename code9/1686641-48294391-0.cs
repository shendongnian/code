     public Camera cam; //You cam goes here
        public Transform target; //you target goes here 
        public void LookAtPosition(Transform lookPosition, float speed)
        {
            cam.transform.LookAt(target);
        }
    }
