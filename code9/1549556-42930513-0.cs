    public string GetCat(int catId, int level = 1, flag cherries = null)
    {
        //get Cat here
        if(level > 0)
        {
            Cat.Owner = ownerRepository.GetById(Cat.OwnerId);
            //load more
        }   
        if(level > 1)
        {
            //and so on
        }
    
        if(cherries.HasFlag(Owner) && Cat.Owner != null)
        {
            Cat.Owner = ownerRepository.GetById(Cat.OwnerId);
        }
        if(cherries.HasFlag(Race) && Cat.Race != null)
        {
            Cat.Race= RaceRepository.GetById(Cat.RaceId);
        }
        //more cherrypicking here
    }
