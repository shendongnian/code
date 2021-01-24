      ...your
      ...code
      ...as above
      listCardSlot.Add(cardSlot3);
      ValueChecker(1);
      double d = mycards.Any() ? mycards.Min(item => item.Price) : 0;
       MessageBox.Show("You need " + incrementer.ToString() + " " + ReturnLowestCardSlot(d).Name);
    }
    int a = 4, b = 5, c = 4;
    int incrementer = 0;
    List<CardSlot> mycards = new List<CardSlot>();
    CardSlot ReturnLowestCardSlot(double lowestPrice)
    {
        CardSlot cardslot = null;
        foreach (var item in mycards)
        {
            if (item.Price == lowestPrice)
            {
                cardslot = item;
                break;
            }
        }
            return cardslot;
    }
    
    void ValueChecker(int increment)
    {
        incrementer += increment;
        foreach (CardSlot item in listCardSlot)
        {
            int i = 1;
            if (((incrementer * item.Card1) >= a) && ((incrementer * item.Card2) >= b) && ((incrementer * item.Card3) >= c))
            {
                if (!(mycards.Contains(item)))
                    mycards.Add(item);
            }
        }
        if (mycards.Count == 0)
           ValueChecker(1);
      }
