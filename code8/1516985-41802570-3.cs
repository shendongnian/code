    using UnityEngine;
    using System.Collections;
    public class LookUpChildren : MonoBehaviour
    {
        void Start()
        {
            var players = GameObject.FindGameObjectsWithName("avatar_5");  
            for (int i = 0; i < players.Length; i++)
            {
                Debug.Log(players[i].name);
                Debug.Log("Player Number " + i + " is named " + players[i].name);
                GetChildren(players[i]);
            }
        }
    
        List<GameObject> GetChildren(GameObject parent)
        {
            List<GameObject> goList = new List<GameObject>();
            for (int i = 0; i < parent.transform.childCount - 1; i++) 
            {
                GameObject child = parent.transform.GetChild(i);
                goList.Add(child);
                Debug.Log(string.Format("{0} is Child of: {1}",child.name, parent.name));
            }        
            return goList;
        }
    
        List<GameObject> FindGameObjectsWithName(string targetName)
        {
            List<GameObject> goList = new List<GameObject>();
            foreach(GameObject go in GameObject.FindObjectsOfType(typeof(GameObject)))
            {
                if(go.name == targetName)
                {
                    goList.Add(go);
                }
            }
            return goList;
        }
    }
