    interface IOwnedBy<T> where T : IOwner 
    { 
        T Owner { get; }
        void SetOwner(T Owner);
    }
    class Person: IOwner { }
    class Cat: IOwner { }
   
    Cat tom = ...
    
    IOwned<Person> owned = ...
    var nope = owned as IOwned<IOwner>;
    nope.SetOwner(tom); //Ouch! Just set a cat as an owner of a IOwned<Person>
