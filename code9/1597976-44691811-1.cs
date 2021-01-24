    public class MyInheritedClass : MyClass
    {
        MyInheritedClass (MyClass baseObject)
        {
            this.UserName = baseObject.UserName; // Do it similarly for rest of the properties
        }
        public string Email { get; set; }
    }
    
    MyInheritedClass inheritedClassObject = new MyInheritedClass(myClassObject);
    inheritedClassObject.GetJson();
