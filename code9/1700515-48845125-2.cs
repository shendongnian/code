    public class Player
    {
      public void playersHand(List<Card> cards)
      {
        this.Hand = cards;
      }
  
      /// ...
  
      public void storeCard(Card card, Piles pile)
      {
        this.StoragePiles.Add(card, pile);
      }
  
      public List<Card> Hand
      {
        get; private set;
      }
  
      public Storage StoragePiles
      {
        get; private set;
      }
    }
