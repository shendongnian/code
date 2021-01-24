     public List<Card> Copy(List<Card> cards) {
       return cards
         .Select(card => new Card() {
            //TODO: put the right assignment here  
            Property1 = card.Property1,
            ...
            PropertyN = card.PropertyN,
         }) 
         .ToList();
     }
