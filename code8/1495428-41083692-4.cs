      public class PlayingCard
        {
            public string suit { get; set; }
            public string face { get; set; }
            public string ImageUrl { get; set; }
            public Image pic { get; set; }
            public int order { get; set; }
            public PlayingCard(string _suit, string _face, int _order)
            {
                suit = _suit;
                face = _face;
                ImageUrl = "\\Images\\" + face + "-of-" + suit + ".png";
                order = _order;
                string _ImageUrl = Application.StartupPath + ImageUrl;
                pic = Image.FromFile(_ImageUrl);
            }
        }
