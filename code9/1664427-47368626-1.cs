    private void CharacterLogout(int charId)
    {
        charactersOnline = charactersOnline.Where(line => line.characterId != charId)
                                           .ToList();
    }
