    public override bool Equals(object obj)
    {
        var that = obj as AlertModel;
    
        return that != null && that.AlertId == this.AlertId && that.CommandId == this.CommandId; 
    }
    
    public override int GetHashCode()
        {           
            int hash = 13;
            return (this.AlertId.GetHashCode() * this.CommandID.GetHashCode()) ^ hash;
        }
