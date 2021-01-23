    using UnityEngine;
    using System.Collections.Generic;
    using System.Linq;
    
    public class rotateCups : MonoBehaviour
    {
        private float lerp = 0f, speed = 5f;
        static List<Vector3> listOfCupPositions, shuffleList;
        Vector3 theNewPos, startPos;
        readonly int shuffleSpeed = 100;
        int shuffle = 0;
    
        void Start()
        {
            if (null == listOfCupPositions)
            {
                // These lists are global to each cup
                listOfCupPositions = new List<Vector3>();
                shuffleList = new List<Vector3>();
            }
            theNewPos = startPos = transform.position;
            listOfCupPositions.Add(theNewPos); // Add this cup to the main list
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
                if (0 == shuffleList.Count)
                    shuffleList = listOfCupPositions.ToList(); // refresh shuffle positions
    
                // Loop until we get a position this cup isn't, 
                // or unless there's only one spot left in shuffle list, 
                // use it (ie don't move this cup this round)
                int index;
                do
                {
                    index = Random.Range(0, shuffleList.Count);
                } while (startPos == shuffleList[index] && shuffleList.Count > 1);
    
                // give this cup a new position
                theNewPos = shuffleList[index];
                shuffleList.RemoveAt(index); // remove position from shuffle list so it isn't duplicated to another cup
            }
        }
    }
