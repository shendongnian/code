        public class Animal { public string animal_name = "Animal"; }
    
        //since we want a different default, we can 
        //either use the *new* keyword to hide the old property default...
        public class Dog : Animal { public new string animal_name = "Dog"; }
        //or we can make the change in the constructor
        public class Dog : Animal 
        {  
            Dog(){ this.animal_name = "Dog"; }
        }
