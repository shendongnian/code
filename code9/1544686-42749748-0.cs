    var buyGroub = BuyShare.GroubBy(x=>x.Id)
                           .Select(x=> new 
                           { name = x.Name,
                             buy = x.Sum(s => s.Share) }
    var soldGroub = SoldShare.GroubBy(x=>x.Id)
                           .Select(x=> new 
                           { name = x.Name,
                             sold = x.Sum(s => s.Share) }
