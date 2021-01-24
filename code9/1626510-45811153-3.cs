    class SpecialPosition
    {
         public int Id {set; set;}
         public string Name {get; set}
         public ICollection<SpecialGood> Goods {get; set;
    }
    class SpecialGood
    {
         public int Id {set; set;}
         public string Name {get; set}
    }
    IEnumerable<SpecialPosition> result = myDbContext.Positions
        .Select(position => new SpecialPosition()                 
        {
            Id = position.Id,
            Name = position.Name,
            Goods = position.Goods
                .Select(good => new SpecialGood()
                {
                    Id = good.Id,
                    Name = good.Name,
                }
                .Where(speicalGood => specialGood.Name == "A"),
        })
        // keep only those items that have at least one Good
        .Where(element => element.Goods.Any());
