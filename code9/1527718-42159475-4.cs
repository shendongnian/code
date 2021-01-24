    Dog pupper = new Dog();
    Cat orion = new Cat();
    petSounds[0].DynamicInvoke( orion );
    petSounds[1].DynamicInvoke( orion );
    petSounds[2].DynamicInvoke( pupper ); // ok, this is a DogSound
    petSounds[3].DynamicInvoke( orion ); // this will fail at runtime because you're passing a Cat into a DogSound delegate
    
