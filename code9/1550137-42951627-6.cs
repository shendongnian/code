    DoggyPet doggy = new DoggyPet();
    doggy.Animal = new Dog(); // OK so far.
    doggy.Bark(); // No problems.
    Pet pet = doggy; // Assign to base class.
    pet.Animal = new Cat(); // Yikes! just changed doggy.Animal to a cat!
    doggy.Bark(); // What happens now! Ooops.
