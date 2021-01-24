        //MyObject class
        
        public class MyObject{
         public string Name{get;set;}
        }
        
    //AnotherObject class
    
        public class AnotherObject{
        public string Name{get;set;}
        }
        
    //Method call
    
        void Main()
        {
          var anotherObject = new AnotherObject() { Name = "Bob" };
          var object1 = new MyObject();
          var obj = object1.Add<MyObject, AnotherObject>(object1, anotherObject);
         //print obj.Name; anywhere.
        }
        
    //Extension Method
    
        static class Ext{
        public static MyObject Add<K,T>(this MyObject myObj, MyObject myObjOne, T value) {
            // MyObject is dictionary<string, object> for simple example
        	string val = typeof(T).GetProperty("Name").GetValue(value).ToString();
            myObjOne.Name = val;
            return myObjOne;
        }
        
        }
