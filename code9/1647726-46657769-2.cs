    using System.Collections.Generic;
    using UnityEngine;
    
    public class MyScript : MonoBehaviour
    {
    
        public int[] box1 = { 1, 0, 2 };
        public int[] box2 = { 3, 1, 0 };
        public int[] box3 = { 2, 3, 1 };
    
    
        public Dictionary<string, int[]> boxes = new Dictionary<string, int[]>();
        private static MyScript instance;
    
        void Awake()
        {
            instance = this;
    
            //Add to Dictionary
            addBox();
    
            int test1 = accessBox("box" + 2, UnityEngine.Random.Range(0, 3));
            Debug.Log(test1);
    
            int test2 = ((MyScript)("box" + 2))[UnityEngine.Random.Range(0, 3)];
            Debug.Log(test2);
    
            int test3 = this["box" + 2][UnityEngine.Random.Range(0, 3)];
            Debug.Log(test3);
    
            int test4 = this["box" + 2, UnityEngine.Random.Range(0, 3)];
            Debug.Log(test4);
        }
    
        void addBox()
        {
            boxes.Add("box1", box1);
            boxes.Add("box2", box2);
            boxes.Add("box3", box3);
        }
    
        public int accessBox(string box, int index)
        {
            //Return the array from the Dictionary
            int[] tempVar;
            if (boxes.TryGetValue(box, out tempVar))
            {
                //Return the spicified index
                return tempVar[index];
            }
            else
            {
                //ERROR - return -1
                return -1;
            }
        }
    
    
        //Indexer overloading (index to int (value in array))
        public int this[int index]
        {
            get
            {
                //Get value based on value set in the implicit operators
                return accessBox(targetBox, index);
            }
        }
    
        static string targetBox = null;
    
        //Implicit conversion operators (box array name to this script(MyScript) instance)
        public static implicit operator MyScript(string box)
        {
            return setTargetAndGetInstance(box);
        }
    
        public static MyScript setTargetAndGetInstance(string box)
        {
            if (instance.boxes.ContainsKey(box))
            {
                //Set the box requested. This will be needed in the Indexer overloading above
                targetBox = box;
                return instance;
            }
            else
                return null;
        }
    
        //Indexer overloading (box array name to this script(MyScript) instance)
        public MyScript this[string box]
        {
            get
            {
                return setTargetAndGetInstance(box);
            }
        }
    
        //Indexer overloading (box array name to int)
        public int this[string box, int index]
        {
            get
            {
                setTargetAndGetInstance(box);
                return accessBox(box, index);
            }
        }
    }
