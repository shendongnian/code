    public class Person  
       {  
      
           private string _name;  
      
           public string Name   
           {   
               get   
               {   
                   return _name;   
               }   
           }  
      
           public Person(string name)  
           {  
               _name = name;  
           }  
      
           public override string ToString()  
           {  
               return _name;  
           }  
      
       }  
