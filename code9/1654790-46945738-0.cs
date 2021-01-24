    public class GameObject
    {
        public Dictionary<string, dynamic> data = new Dictionary<string, dynamic>();
        public GameObject()
        {
        }
        //Overloads the [] operator to allow array style access
        public dynamic this[string key]
        {
            get { return this.data[key]; }
            set { data[key] = value; }
        }
        public Dictionary<string, dynamic>.Enumerator GetEnumerator()
        {
            return data.GetEnumerator();
        }
    }
