    using UnityEngine;
    
    public class blackBox : MonoBehaviour {
        public bool toggleRight;
    
        // Update is called once per frame
        void Update () {
    		if(toggleRight)
            {
                foreach(Transform child in transform)
                {
                    if(child.name.Equals("ArrowRight"))
                    {
                        child.gameObject.SetActive(!child.gameObject.activeSelf);
                    }
                }
                toggleRight = false;
            }
    	}
    }
