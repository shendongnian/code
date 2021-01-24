      public override int GetHashCode(){
            return this.FirstName.GetHashCode() ^ 
                   this.LastName.GetHashCode() ^ 
                   this.Address.GetHashCode(); 
        }
    
