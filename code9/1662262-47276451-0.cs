    public class MyClass
    {
        public GameObject object1 = new GameObject("g1");
        public GameObject object2 = new GameObject("g2");
        public GameObject object3 = new GameObject("g3");
    
        public void AddObject()
        {
            List<GameObject> list = new List<GameObject>();
    
            for (int i = 1; i <= 3; i++)
            {
                var o = this.GetType().GetField($"object{i}").GetValue(this) as GameObject;    
                list.Add(o);
            }           
        }
    }
