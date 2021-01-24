    public class Wire
    {
        public List<Wire> connectedWires = new List<Wire>();
    
        //Example var we want to set
        public int i = 0;
    
        public void Initialize()
        {
        //Initialization code
        //Here we get all connected wires the actual one (this) and we put it in   connected wire
        }
        public void LoopThroughWires()
        {
            //Do something with your wires or whatever
            i++;
            //Propagate to childs
            foreach(Wire wire on connectedWires)
            {
                wire.LoopThroughWires();
            }
        }
    }
