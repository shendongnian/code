    public class ClassStudents {
    
       public Id {get; set;}
       public Name {get; set;}
       
       public override bool Equals(object obj) {
                return this.Name.Trim().ToLower().Equals(((ClassStudents)obj).Name.Trim().ToLower());
       }
    
       public override int GetHashCode() {
           return this.Name.GetHashCode();
       }
    }
