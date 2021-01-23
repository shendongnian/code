    Dog lassie = new Dog();
    lassie.Name = "Lassie";
    Dog krypto = new Dog();
    krypto.Name = "Krypto";
    krypto.IsCute = true;
    Animal grumpyCat = new Animal();
    grumpyCat.Name = "Grumpy Cat :(";
    grumpyCat.Age = 7;
    Animal dumbo = new Animal();
    dumbo.Name = "Dumbo";
    dumbo.Age = 75;
    // Call a method on Lassie, passing in three other objects as parameters:
    lassie.Sight(dumbo, grumpyCat, krypto);
