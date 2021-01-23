    using UnityEngine;
    
    public class Smoke1 : MonoBehaviour
    {
        public GameObject myPrefab;
        public GameObject canvasObject;
    
        void Start()
        {
            GameObject temp = Instantiate(myPrefab, new Vector3(0, -25, 90), Quaternion.Euler(-90, 0, 0)) as GameObject;
            temp.transform.SetParent(canvasObject.transform, false);
            temp.transform.localScale = new Vector3(1, 1, 1);
        }
    }
