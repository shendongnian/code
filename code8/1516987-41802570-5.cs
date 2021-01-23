    using UnityEngine;
    using System.Collections;
    using System.Collections.Generic;
    
    public class ReadAllGOs : MonoBehaviour
    {
        void Start()
        {
            Debug.Log("Start");
            var parent = FindParentGameObjectsWithName();
            for (int i = 0; i < parent.Count; i++)
            {
                Debug.Log("--> Parent Number " + i + " is named: " + parent[i].name);
                ReadChildren(parent[i]);
            }
        }
    
        List<GameObject> FindParentGameObjectsWithName()
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
