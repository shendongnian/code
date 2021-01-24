    // method in third file
    public static string FormatName(Character.Character instance) {
        return $"{instance.Name} {instance.Surname}";
    }
    
    // instantition and usage in second file
    Character.Character character = new Character.Character {
        Name = CharacterController.LoadCharacterData(player).Result[0].Name,
        Surname = CharacterController.LoadCharacterData(player).Result[0].Surname
    };
    
    var formated = FormatName(character);
