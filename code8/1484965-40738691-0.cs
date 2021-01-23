       byte[] extraData = ...
    
       ...
    
       public bool Equals(MessageType other) {
         ...
         
         if (!Enumerable.SequenceEqual(extraData, other.extraData))
           return false;
    
         ...  
       } 
       
       public override int GetHashCode() {
         int result = ...
    
         ...  
         // let's combine hashes with xor
         result ^= extraData == null 
          ? 0
          : extraData.Aggerate(0, (s, a) => s ^ a); // ...and aggerate with xor as well
    
         ...
       }
