     public List<CardBase> GetRandExclude(List<CardBase> list, int elementsCount, List<CardBase> excludeList)
            {
                var returnCards = from card in list
                                  where !excludeList.Contains(card)
                                  select card;
                foreach (CardBase cd in returnCards.Take(elementsCount))
                {
                    //Debug.Log("Selected random card is " + cd.name);
                }
                IEnumerable<CardBase> newList = returnCards.Take(elementsCount);
                return newList.ToList();
            }
