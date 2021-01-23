    using UnityEngine;
    using System.Collections;
    
    public class NewBehaviourScript : MonoBehaviour
    {
        //making them public just to be able watch values change in game mode
        public float movementSpeed = 10;
        public GameObject g1;
        public GameObject g2;
        public Vector3 vec1;
        public Vector3 vec2 = new Vector3(2F, 2F, 2F);
        public bool swapBack = false;
        void Start()
        {
            g1 = GameObject.Find("Cube");
            g2 = GameObject.Find("Sphere");
            vec1 = new Vector3(g1.gameObject.transform.position.x, g1.gameObject.transform.position.y, g1.gameObject.transform.position.z);
            vec2 = new Vector3(g2.gameObject.transform.position.x, g2.gameObject.transform.position.y, g2.gameObject.transform.position.z);
        }
    
        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                transform.Translate(Vector3.right * movementSpeed * Time.deltaTime);
                swap(swapBack);
            }
        }
    
        public void swap(bool back)
        {
            if (back)
            {
                g1.transform.position = vec1;
                g2.transform.position = vec2;
                swapBack = false;
            }
            else
            {
                g1.transform.position = vec2;
                g2.transform.position = vec1;
                swapBack = true;
            }
        }
    }
