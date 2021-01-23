    public class NPC : Character
    {
    
        public bool isVender;
    
        public NPC() : base()
        {
            isVender = false;
        }
    
        public NPC(string a_name, List<String> images) : base(a_name, images)
        {
            isVender = false;
        }
    
        public NPC(string a_name, List<string> images, bool a_bool) : base(a_name, images)
        {
            isVender = a_bool;
        }
    
    }
