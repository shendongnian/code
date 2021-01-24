    public class SerialNumber 
    {
        //other stuff....
        [InverseProperty("SerialNumber")]
        public virtual ICollection<RepairProcess> SerialNumbers {get;set;}
    
        [InverseProperty("ReplacementSerialNumber")]
        public virtual ICollection<RepairProcess> ReplacementSerialNumbers {get;set;}
    }
