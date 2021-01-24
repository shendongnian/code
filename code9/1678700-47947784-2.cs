    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    
    public class DroidMove : MonoBehaviour
    {
        public GameObject droid;
        public ChangeScale changeScale;
    
        private float distance;
        private Camera cam; 
    
        private void Start()
        {
            cam = GetComponent<Camera>();
            distance = Vector3.Distance(cam.transform.position, droid.transform.position);
            droid.SetActive(false);
        }
    
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                droid.SetActive(!droid.activeInHierarchy);
                changeScale.Scale(droid.activeInHierarchy);
            }
        }
    }
