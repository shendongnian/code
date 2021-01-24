    List<ComputerCard> SortedCards = cards.OrderBy(                    
                       x => x.CardRoles.Sum(y => y.DependentRoles.Count))
                       .ToList();
    foreach (var item in SortedCards)
    {
        item.CardRoles = item.CardRoles
               .OrderByDescending(x => x.DependentRoles.Count).ToList();
    }
    
