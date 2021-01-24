    while(true)
    {
        // Here non combat characters do something.
        foreach(NonCombatCharacter character in NonCombatCharacters)
        {
            switch(character.Type)
            {
                case tinyBird: character.DoAction(Actions.Fly); break;
                case ...
                default:break;
            }
        }
        // Here your combat character aka enemies
        foreach(CombatCharacter character in CombatCharacters)
        {
            // Here you do your combat logic, cheks and etc.
        }
        // And then you player character change the world model, here you
        // process all player action such as changing position, losing hp.
        // And then world keep lifecycle again
    }
