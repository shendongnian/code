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
                int CountSub = 0;
                CountSub = DB.Categories.Where(x => x.Level == item.Id).ToList().Count();
                if (CountSub!=0)
                {
                    item.Subs = Categories(item.Id).ToList();
                }
            }
            return DTO;
        }
    }
