    var characterList = from characters in ContextFactory.Instance.Characters
                        where characters.UserId == user.Id
    
                        join t in ContextFactory.Instance.CharacterTraits
                        on characters.Id equals t.CharacterId into traits 
                        join c in ContextFactory.Instance.CharacterClothes into clothes
                        on characters.Id equals c.CharacterId
                        select new { /* As before */ }
