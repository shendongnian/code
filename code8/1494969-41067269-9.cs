    using UnityEngine;
    using System.Linq;
    
    public class Shaker : MonoBehaviour
    {
        Cup[] cups;
    
        void Start()
        {
            cups = GameObject.FindObjectsOfType<Cup>();
        }
    	  	
    	void Update ()
        {
   
        }
    
        void Shake()
        {
            int[] newIndices = Enumerable.Repeat(-1, cups.Length).ToArray();
    
            for (int i = 0; i < cups.Length; i++) //there could be another random sort algorithm, for example to make that every cup would move to another spot.
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
