    var character = (from characters in ContextFactory.Instance.Characters
                     join t in ContextFactory.Instance.CharacterTraits
                     on characters.Id equals t.CharacterId into traits 
                     join c in ContextFactory.Instance.CharacterClothes into clothes
                     on characters.Id equals c.CharacterId
                     select new { /* As before */ }).FirstOrDefault( x=> x.id = user.Id);
