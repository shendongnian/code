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
                list = new List<Vector3>();
                list2 = new List<Vector3>();
            }
            theNewPos = startPos = transform.position;
            list.Add(theNewPos);
        }
    
        void Update()
        {
            if (startPos != theNewPos)
            {
                lerp += Time.deltaTime * speed;
                lerp = Mathf.Clamp(lerp, 0f, 1f);
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
                shuffle = shuffleSpeed;
                if (0 == list2.Count)
                    list2 = list.ToList(); // refresh list of positions
    
                int index;
                do
                {
                    index = Random.Range(0, list2.Count);
                } while (startPos == list2[index] && list2.Count > 1);
    
                theNewPos = list2[index];
                list2.RemoveAt(index);
            }
        }
    }
