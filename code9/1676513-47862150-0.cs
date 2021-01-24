    // Implement ICloneable to clone the object
    public class ControlViewModel : ICloneable
    { 
      public string FieldType { get; set; } 
      public string FieldName { get; set; } 
      public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
    
    ControlViewModel cvm = new ControlViewModel(); 
    cvm.FieldType ="TEXT"; cvm.FieldName ="TEXT1";
    // Copy object    
    ControlViewModel cvm2 = (ControlViewModel)cvm.Clone() ;
    cvm2.FieldName ="TEXT2";
