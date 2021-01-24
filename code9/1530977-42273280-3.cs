    var foo = GetAnimalById(animalId); // Animal type returned to foo
    var animal = new Animal(); // Animal class hasn't Age property and GiveVitamins method
    if (foo is VitaminReceivable && foo is Ageable) { 
        animal = foo; 
        if (((Ageable)animal).Age >= 10)
        {
            ((VitaminReceivable)animal).ReceiveVitamins();
        }
    }
