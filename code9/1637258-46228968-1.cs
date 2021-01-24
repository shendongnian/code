    public class Person
    {
        public string Name { get; set; }
    }
    ArrayList a = new ArrayList(); // New object, reference in a
    a.Add(new Person(){Name = "Jack"}); // New person object, reference added to a.
    a.Add(new Person(){Name = "Jill"}); // New person object, reference added to a.
    ArrayList b = (ArrayList)a.Clone(); // New ArrayList object created, references 
                                        // to both Person objects are copied to it, 
                                        // then the reference to the new ArrayList 
                                        // is stored in b.
