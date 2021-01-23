    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        protected void btnload_Click(object sender, EventArgs e)
        {
            string[] suit = { "Clubs", "Diamonds", "Hearts", "Spades" };
            string face = "";
            int counter = 0;
            List<PlayingCard> cardDeckList = new List<PlayingCard>();
            for (int i = 0; i < 4; i++)
            {
                for (int k = 0; k < 13; k++)
                {
                    if (k < 9)
                        face = k.ToString();
                    else
                    {
                        switch (k)
                        {
                            case 9:
                                face = "Jack";
                                break;
                            case 10:
                                face = "Queen";
                                break;
                            case 11:
                                face = "King";
                                break;
                            case 12:
                                face = "Ace";
                                break;
                        }
                    }
                    cardDeckList.Add(new PlayingCard(suit[i], face, counter));
                    counter++;
                }
            }
            gvCards.DataSource = cardDeckList.ToList().OrderBy(c => c.order);
            gvCards.DataBind();
        }
    }
    public class PlayingCard
    {
        public string suit { get; set; }
        public string face { get; set; }
        public string ImageUrl { get; set; }
        public int order { get; set; }
        public PlayingCard(string _suit, string _face, int _order)
        {
            suit = _suit;
            face = _face;
            //ImageUrl = "Url Of Images in virtual directory" 
            ImageUrl = "~/Images/" + face + "-of-" + suit;
            order = _order;
        }
    }
