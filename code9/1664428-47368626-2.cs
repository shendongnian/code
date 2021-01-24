    var indexesToRemove = 
        charactersOnline.Select((line, index) => (Id: line.characterId, Index: index))
                        .Where(item => item.Id == charId)
                        .Select(item => item.Index);
    foreach (var index in indexesToRemove)
    {
        charactersOnline.RemoveAt(index);
    }
    
   
