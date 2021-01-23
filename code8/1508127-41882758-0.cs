    using UnityEngine;
    
    public class MapManager : MonoBehaviour
    {
        Color normalColor = Color.red;
    
        Color mouseDownColor = Color.green;
        Color mouseEnterColor = Color.yellow;
    
        // Use this for initialization
        void Start()
        {
    
        }
    
        // Update is called once per frame
        void Update()
        {
    
        }
    
        public void mapclick(GameObject objClicked)
        {
            Debug.Log("Clicked: " + objClicked.name);
        }
    
        public void mapMouseDown(GameObject objClicked)
        {
            Debug.Log("Pointer Down: " + objClicked.name);
    
            MeshRenderer mr = objClicked.GetComponent<MeshRenderer>();
            mr.material.color = mouseDownColor;
        }
    
        public void mapMouseUp(GameObject objClicked)
        {
            Debug.Log("Pointer Up: " + objClicked.name);
    
            MeshRenderer mr = objClicked.GetComponent<MeshRenderer>();
            mr.material.color = normalColor; ;
        }
    
        public void mapMouseEnter(GameObject objClicked)
        {
            Debug.Log("Pointer Enter: " + objClicked.name);
    
            MeshRenderer mr = objClicked.GetComponent<MeshRenderer>();
            mr.material.color = mouseEnterColor;
        }
    
        public void mapMouseExit(GameObject objClicked)
        {
            Debug.Log("Pointer Exit: " + objClicked.name);
    
            MeshRenderer mr = objClicked.GetComponent<MeshRenderer>();
            mr.material.color = normalColor;
        }
    }
