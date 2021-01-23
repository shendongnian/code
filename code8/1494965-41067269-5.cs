    using UnityEngine;
    using System.Linq;
    
    public class Shaker : MonoBehaviour
    {
        Tests[] cups;
    
        void Start()
        {
            cups = GameObject.FindObjectsOfType<Tests>();
        }
    	  	
    	void Update ()
        {
   
        }
    
        void Shake()
        {
            int[] newIndices = Enumerable.Repeat(-1, cups.Length).ToArray();
    
            for (int i = 0; i < cups.Length; i++)
            {
                int free = cups.Length - i;
                int j = Random.Range(0, free);
    
                for (int k = j; k < cups.Length; k++)
                {
                    if (newIndices[k] == -1)
                    {
                        newIndices[k] = i;
                        break;
                    }
                }
            }
    
            for (int i = 0; i < cups.Length; i++)
            {
                cups[i].MoveToSpot(cups[newIndices[i]].startPos);
            }
        }
    }
