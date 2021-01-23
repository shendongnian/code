    using UnityEngine;
    using System.Collections;
    using System.Collections.Generic;
    
    public class ReadAllGOs : MonoBehaviour
    {
        void Start()
        {
            var parents = FindParentGameObjects();
            for (int i = 0; i < parents.Count; i++)
            {
                Debug.Log("--> Parent Number " + i + " is named: " + parents[i].name);
                ReadChildren(parents[i]);
            }
        }
    
        List<GameObject> FindParentGameObjects()
        {
            List<GameObject> goList = new List<GameObject>();
            foreach (GameObject go in GameObject.FindObjectsOfType(typeof(GameObject)))
            {
                if (go.transform.parent == null)
                {
                    goList.Add(go);
                }
            }
            return goList;
        }
    
        void ReadChildren(GameObject parent)
        {
            for (int i = 0; i < parent.transform.childCount; i++)
            {
                GameObject child = parent.transform.GetChild(i).gameObject;
                Debug.Log(string.Format("{0} has Child: {1}", parent.name, child.name));
                // inner Loop
                ReadChildren(child);
            }
        }
    }
