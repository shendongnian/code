    using UnityEngine;
    
    public class Smoke1 : MonoBehaviour
    {
        public GameObject myPrefab;
        public GameObject canvasObject;
    
        void Start()
        {
            GameObject newSmoke = Instantiate(myPrefab, new Vector3(0, -25, 90), Quaternion.Euler(-90, 0, 0)) as GameObject;
            newSmoke.transform.SetParent(canvasObject.transform, false);
            newSmoke.transform.localScale = new Vector3(1, 1, 1);
        }
    }
