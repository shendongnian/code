        public class Animal { public string animal_name = "Animal"; }
    
        //since we want a different default, we can 
        //can make the change in the constructor
        public class Dog : Animal 
        {  
            Dog(){ this.animal_name = "Dog"; }
            //if you really, really want a second name string, you can do this:
            public string Dog_Name 
            {
               get { return this.animal_name; } 
               set { this.animal_name = value; }
            }
        }
        
