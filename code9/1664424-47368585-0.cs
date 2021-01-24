    var charactersOnline = new List<CharactersOnline>();
    var target = charactersOnline.SingleOrDefault(x => x.characterId == 1);
    if(target != null)
    {
        charactersOnline.Remove(target);
    }
