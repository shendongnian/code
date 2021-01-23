    var character = new Character();
    CharacterState state = character.State; // returns Idle.
    // or set it
    character.State = CharacterState.Attacking;
    Console.WriteLine($"Take cover! character is {character.State}");
    //- logs "Take cover! character is Attacking"
