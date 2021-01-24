    var foo = GetAnimalById(animalId); // Animal type returned to foo
    var animal = new Animal(); // Animal class hasn't Age property and GiveVitamins method
    if (foo is VitaminReceivable) { 
        animal = foo; 
        if (animal.Age >= 10)
        {
            ((VitaminReceivable)animal).GiveVitamins();
        }
    }
