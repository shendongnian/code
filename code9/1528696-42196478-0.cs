    public enum Suits
    {
        Spades,
        Hearts,
        Clubs,
        Diamonds
    }
    public enum Ranks
    {
        Ace,
        _2,
        _3,
        _4,
        _5,
        _6,
        _7,
        _8,
        _9,
        _10,
        Jacks,
        Queen,
        King
    }
    public class CardClass
    {
        public static CardClass[] GetFiveInitialCards()
        {
            return new CardClass[] {
                new CardClass(Suits.Spades, Ranks.Ace),
                new CardClass(Suits.Spades, Ranks._7),
                new CardClass(Suits.Hearts, Ranks.Ace),
                new CardClass(Suits.Clubs, Ranks._5),
                new CardClass(Suits.Diamonds, Ranks._2)
            };
        }
        public Suits Suit { get; }
        public Ranks Rank { get; }
        public CardClass(Suits suit, Ranks rank)
        {
            this.Suit = suit;
            this.Rank = rank;
        }
    }
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
    
        int play1choice, play2choice;
        private readonly Random rnd = new Random();
    
        private void btnCard_Click(object sender, EventArgs e)
        {
            CardClass[] initialCards = CardClass.GetFiveInitialCards();
            int Player1 = (rnd.Next(5) + 1);
            CardClass player1Card = initialCards[Player1];
            int Player2 = (rnd.Next(5) + 1);
            CardClass player2Card = initialCards[Player2];
    
        }
    }
