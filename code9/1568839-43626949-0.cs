    public class Robot
    {
        public string name;
        public int id;
    
        public Robot(string name, int id)
        {
            this.name = name;
            this.id = id;
        }
    
        // Here start's the magic!
        public override string ToString()
        {
            return string.Format("Robot -> Id:'{0}' Name:'{1}'", id, name);
        }
    }
