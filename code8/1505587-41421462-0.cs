    public class Cars
    {    
         // Properties      
         public string Make { get; set; }
         public string Model { get; set; }
         public int Year { get; set; }
         public string Location_State { get; set; }
    
         // overrided  Equals method definition
         public override bool Equals(object obj)
         {
             return this.Equals(obj as Cars);
         }
         public bool Equals(Cars other)
         {
             if (other == null)
                 return false;
             return (this.Make == other.Make) &&
                    (this.Model == other.Model) &&
                    (this.Year == other.Year) &&
                    (this.Location_State == other.Location_State);
         }
    }
