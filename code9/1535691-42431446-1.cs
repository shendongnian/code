    public class Element()
    {
     //Question point is this get{}
     //Everytime I access the instance of this class this get would be called
     get{
    
       return this;
    
     }
    
     public string AnyProperty {get; set;}
    
    }
    
    public class AnotherClass()
    {
    
     public void AccessElement()
     {
      Element element = new Element();
      element.AnyProperty = ""; 
     }
    
    }
