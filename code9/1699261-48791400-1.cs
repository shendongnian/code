    using UnityEngine;
    
    public class FormShifting : MonoBehaviour {
    
        public GameObject myObject1;
        public GameObject myObject2;
        int high;
    
        void Update () {
    
            if (Input.GetKeyDown(KeyCode.UpArrow) && high == 0)
            {
                myObject1.SetActive(false);
                myObject2.SetActive(true);
                high = 1;
            }
    
            if (Input.GetKeyDown(KeyCode.DownArrow) && high == 1)
            {
                myObject2.SetActive(false);
                myObject1.SetActive(true);
                high = 0;
            }
        }
    }
