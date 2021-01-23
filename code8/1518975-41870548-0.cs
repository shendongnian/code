    public class ObjectData
    {
        public string ID;
        public string hierarchyParent;
        public int hierarchyLevel;
    }
    		
    void Main()
    {
    
    	var objects = new List<ObjectData>() { 
    	new ObjectData() { ID = "Obj12", hierarchyParent = null }, 
    	new ObjectData() { ID = "Obj5", hierarchyParent = "Obj12" }, 
    	new ObjectData() { ID = "Obj9", hierarchyParent = "Obj12" },
    	new ObjectData() { ID = "Obj7", hierarchyParent = "Obj5" },
    	new ObjectData() { ID = "Obj99", hierarchyParent = "Obj58" },
    	new ObjectData() { ID = "Obj58", hierarchyParent = "Obj5" } };
    
    	ObjectData top = objects.Find(p => p.hierarchyParent == null);
    	top.hierarchyLevel = 1;
    	
    	AssignChild(objects, top);
    	
    	objects.Dump();
    }
    
    void AssignChild(List<ObjectData> all, ObjectData parent)
    {
    	var child = all.FindAll(o => o.hierarchyParent == parent.ID);
    	child.ForEach(c => { c.hierarchyLevel = parent.hierarchyLevel +1; AssignChild(all, c); });
    }
