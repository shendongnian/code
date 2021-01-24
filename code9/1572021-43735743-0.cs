    public List<CategoriesDTO> Categories(int PrmLevel)
    {
        List<CategoriesDTO> DTO = new List<CategoriesDTO>();
        //DB is my dbcontext.
        DTO = DB.Categories.Select(x => new CategoriesDTO()
        {
            Id = x.Id,
            Level = x.Level,
            Name = x.Name
            }).Where(y => y.Level == PrmLevel).ToList();
            foreach (var item in DTO)
            {
                item.Subs = ((PrmLevel + 1) <= MaxLevel) ? Categories(PrmLevel + 1) : null;
            }
            return DTO;
        }
    }
