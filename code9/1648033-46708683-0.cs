    public partial class Form1 : Form
    {
    	List<Card> deck = new List<Card>(); //allready has 52 cards in it.
    	List<Card> fiveRandomCards = new List<Card>(); 
    	Random random = new Random();
    	
    	private void Form1_Load(object sender, EventArgs e)
            {
                for (int symbol = 1; symbol < 5; symbol = symbol + 1)
                {
                    for (int value = 1; value < 14; value = value + 1)
                        deck.Add(new Card((Symbol)symbol, (Value)value));
                }
            }
    	private void RandomButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 5; i = i + 1)
                fiveRandomCards.Add(deck[random.Next(0, deck.Count)]); 
    		CardsLB.Items.Clear();
            foreach (Card card in fiveRandomCards)
                CardsLB.Items.Add(card.name);                
        }
    }
