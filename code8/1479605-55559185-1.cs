    struct Person
    {
        public StringClass name;
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            Person person_1 = new Person();
            person_1.name = new String("Person 1"); //imagine the reference value of name is "m1", which points somewhere into the memory where "Person 1" is saved
    
            Person person_2 = person_1; //person_2.name holds the same reference, that is "m1" that was copied from person_1.name 
            person_2.name = new String("Person 2"); //person_2.name now holds a new reference "m2" to  a new StringClass object in the memory, person_1.name still have the value of "m1"
            person_1.name = person_2.name //this copies back the new reference "m2" to the original struct
    
            Console.WriteLine(person_1.name);
            Console.WriteLine(person_2.name);
        }
    }
