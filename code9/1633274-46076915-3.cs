    class CostCode
    {
        //... property definition of Id and Text
    
        
        public override bool Equals(System.Object obj)
        {
            // If parameter is null return false.
            if (obj as  == null)
            {
                return false;
            }
    
            // If parameter cannot be cast to CostCode return false.
            CostCode cc = obj as CostCode;
            if (cc == null)
            {
                return false;
            }
    
            // Return true if the Id fields match:
            return Id == cc.Id;
        }
    
        public override int GetHashCode()
        {
            return Id; // If Id is int...
        }
    }
