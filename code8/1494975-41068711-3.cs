    using UnityEngine;
    using System.Collections.Generic;
    using System.Linq;
    
    public class rotateCups : MonoBehaviour
    {
        private float lerp = 0f, speed = 5f;
        static List<Vector3> list, list2;
        Vector3 theNewPos, startPos;
        readonly int shuffleSpeed = 100;
        int shuffle = 0;
    
        void Start()
        {
            if (null == list)
            {
                // These lists are global to each cup
                list = new List<Vector3>();
                list2 = new List<Vector3>();
            }
            theNewPos = startPos = transform.position;
            list.Add(theNewPos); // Add this cup to the main list
        }
    
        void Update()
        {
            if (startPos != theNewPos)
            {
                lerp += Time.deltaTime * speed;
                lerp = Mathf.Clamp(lerp, 0f, 1f); // keep lerp between the values 0..1
                transform.position = Vector3.Lerp(startPos, theNewPos, lerp);
                if (lerp >= 1f)
                {
                    startPos = theNewPos;
                    lerp = 0f;
                }
            }
        }
    
        void LateUpdate()
        {
            if (--shuffle <= 0)
            { 
                // Shuffle the cups
                shuffle = shuffleSpeed;
                if (0 == list2.Count)
                    list2 = list.ToList(); // refresh list of positions
    
                // Loop until we get a position this cup isn't, 
                // or unless there's only one spot left in list2, 
                // use it (ie don't move this cup this round)
                int index;
                do
                {
                    index = Random.Range(0, list2.Count);
                } while (startPos == list2[index] && list2.Count > 1);
    
                // give this cup a new position
                theNewPos = list2[index];
                list2.RemoveAt(index); // remove position from 2nd list so it isn't duplicated to another cup
            }
        }
    }
