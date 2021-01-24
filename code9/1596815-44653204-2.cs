    class A
    { 
        public string Name
         {
           get;
           private set;
         } 
    }
    class B:A 
    { 
       public B()
        {
          this.Name = "Derived"; // This will not work. If you want to prevent the derived class from accessing the field, just mark the field as private instead of public.
        }
    }
